using AutoMapper;
using Cavex.Principal.API.Dtos.CatServicios;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications;
using Cavex.Principal.Core.Specifications.CatServicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    /// <summary>
    /// Expone endpoints CRUD para administrar registros de CatServicios.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatServiciosController : ControllerBase
    {
        private const string CachePrefix = "CatServicios";
        private readonly IGenericRepository<CatServicios> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public CatServiciosController(
            IGenericRepository<CatServicios> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        /// <summary>
        /// Obtiene una lista paginada de registros.
        /// </summary>
        /// <param name="pagination">Parametros de paginacion y busqueda aplicados a la consulta.</param>
        /// <returns>Respuesta paginada con los registros encontrados.</returns>
        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<CatServiciosDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<CatServiciosDto>>>> GetAll(
            [FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}:Status={pagination.Status}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<CatServiciosDto>>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new CatServiciosSpecification(
                pagination.Search,
                pagination.Status,
                pagination.PageIndex,
                pagination.PageSize);

            var countSpecification = new CatServiciosCountSpecification(pagination.Search, pagination.Status);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);
            var dto = _mapper.Map<IReadOnlyList<CatServiciosDto>>(entities);

            var response = new ResponseWrapper<PagedResponse<CatServiciosDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<CatServiciosDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = dto
                }
            };

            _cache.Set(
                cacheKey,
                response,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2)
                });

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [EnableRateLimiting("CatalogReadPolicy")]
        [SwaggerOperation(
            Summary = "Consultar servicio por Id",
            Description = "Obtiene un registro especifico del catalogo de servicios mediante su identificador."
        )]

        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseWrapper<object>), StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<ResponseWrapper<CatServiciosDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<CatServiciosDto>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new CatServiciosSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<CatServiciosDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el servicio solicitado.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<CatServiciosDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<CatServiciosDto>(entity)
            };

            _cache.Set(
                cacheKey,
                response,
                new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                    SlidingExpiration = TimeSpan.FromMinutes(3)
                });

            return Ok(response);
        }

        /// <summary>
        /// Crea un nuevo registro.
        /// </summary>
        /// <param name="request">Cuerpo de la solicitud con los datos validados por el contrato de entrada.</param>
        /// <returns>Registro creado con su informacion persistida.</returns>
        [HttpPost]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<CatServiciosDto>>> Create(
            [FromBody] RequestWrapper<CatServiciosCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<CatServiciosDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<CatServicios>(request.Body);

            _repository.Add(entity);

            await _repository.SaveAllAsync();

            InvalidateListCache();

            var dto = _mapper.Map<CatServiciosDto>(entity);

            var response = new ResponseWrapper<CatServiciosDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Servicio creado correctamente.",
                Data = dto
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }

        /// <summary>
        /// Actualiza un registro existente por su identificador.
        /// </summary>
        /// <param name="id">Identificador unico del registro.</param>
        /// <param name="request">Cuerpo de la solicitud con los datos validados por el contrato de entrada.</param>
        /// <returns>Registro actualizado o una respuesta 404 cuando no existe.</returns>
        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<CatServiciosDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<CatServiciosDto>>> UpdateById(
            int id,
            [FromBody] RequestWrapper<CatServiciosUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<CatServiciosDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new CatServiciosSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<CatServiciosDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el servicio solicitado.",
                    Data = null
                });
            }

            entity.StrValor = request.Body.StrValor;
            entity.StrDescripcion = request.Body.StrDescripcion;
            entity.IdCatStatus = request.Body.IdCatStatus;

            _repository.Update(entity);

            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<CatServiciosDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Servicio actualizado correctamente.",
                Data = _mapper.Map<CatServiciosDto>(entity)
            });
        }

        /// <summary>
        /// Elimina un registro existente por su identificador.
        /// </summary>
        /// <param name="id">Identificador unico del registro.</param>
        /// <returns>Resultado de la eliminacion solicitada.</returns>
        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var specification = new CatServiciosSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el servicio solicitado.",
                    Data = false
                });
            }

            _repository.Remove(entity);

            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<bool>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Servicio eliminado correctamente.",
                Data = true
            });
        }

        private void InvalidateEntityCache(int id)
        {
            _cache.Remove($"{CachePrefix}:Id:{id}");
        }

        private static void InvalidateListCache()
        {
            Interlocked.Increment(ref _listCacheVersion);
        }
    }
}
