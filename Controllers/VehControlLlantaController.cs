using AutoMapper;
using Cavex.Principal.API.Dtos.VehControlLlanta;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.VehControlLlanta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    /// <summary>
    /// Expone endpoints CRUD para administrar registros de VehControlLlanta.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehControlLlantaController : ControllerBase
    {
        private const string CachePrefix = "VehControlLlanta";
        private readonly IGenericRepository<VehControlLlanta> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public VehControlLlantaController(IGenericRepository<VehControlLlanta> repository, IMapper mapper, IMemoryCache cache)
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
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<VehControlLlantaDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<VehControlLlantaDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<VehControlLlantaDto>>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new VehControlLlantaSpecification(pagination.Search, pagination.PageIndex, pagination.PageSize);
            var countSpecification = new VehControlLlantaCountSpecification(pagination.Search);
            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);
            var dto = _mapper.Map<IReadOnlyList<VehControlLlantaDto>>(entities);

            var response = new ResponseWrapper<PagedResponse<VehControlLlantaDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<VehControlLlantaDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = dto
                }
            };

            _cache.Set(cacheKey, response, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            });

            return Ok(response);
        }

        /// <summary>
        /// Obtiene un registro por su identificador.
        /// </summary>
        /// <param name="id">Identificador unico del registro.</param>
        /// <returns>Registro encontrado o una respuesta 404 cuando no existe.</returns>
        [HttpGet("{id:int}")]
        [EnableRateLimiting("CatalogReadPolicy")]
        [SwaggerOperation(Summary = "Consultar control llanta por Id", Description = "Obtiene un registro especifico de control llanta mediante su identificador.")]
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseWrapper<object>), StatusCodes.Status429TooManyRequests)]
        public async Task<ActionResult<ResponseWrapper<VehControlLlantaDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<VehControlLlantaDto>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new VehControlLlantaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<VehControlLlantaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el registro solicitado.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<VehControlLlantaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<VehControlLlantaDto>(entity)
            };

            _cache.Set(cacheKey, response, new MemoryCacheEntryOptions
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
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<VehControlLlantaDto>>> Create([FromBody] RequestWrapper<VehControlLlantaCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<VehControlLlantaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<VehControlLlanta>(request.Body);
            _repository.Add(entity);
            await _repository.SaveAllAsync();
            InvalidateListCache();

            var dto = _mapper.Map<VehControlLlantaDto>(entity);

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, new ResponseWrapper<VehControlLlantaDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Registro creado correctamente.",
                Data = dto
            });
        }

        /// <summary>
        /// Actualiza un registro existente por su identificador.
        /// </summary>
        /// <param name="id">Identificador unico del registro.</param>
        /// <param name="request">Cuerpo de la solicitud con los datos validados por el contrato de entrada.</param>
        /// <returns>Registro actualizado o una respuesta 404 cuando no existe.</returns>
        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<VehControlLlantaDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<VehControlLlantaDto>>> UpdateById(int id, [FromBody] RequestWrapper<VehControlLlantaUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<VehControlLlantaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new VehControlLlantaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<VehControlLlantaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el registro solicitado.",
                    Data = null
                });
            }

            _mapper.Map(request.Body, entity);
            _repository.Update(entity);
            await _repository.SaveAllAsync();
            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<VehControlLlantaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Registro actualizado correctamente.",
                Data = _mapper.Map<VehControlLlantaDto>(entity)
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
            var specification = new VehControlLlantaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el registro solicitado.",
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
                Message = "Registro eliminado correctamente.",
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
