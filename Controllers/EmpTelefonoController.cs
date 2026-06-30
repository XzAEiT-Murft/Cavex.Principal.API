using AutoMapper;
using Cavex.Principal.API.Dtos.EmpTelefono;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpTelefono;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    /// <summary>
    /// Expone endpoints CRUD para administrar registros de EmpTelefono.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpTelefonoController : ControllerBase
    {
        private const string CachePrefix = "EmpTelefono";
        private readonly IGenericRepository<EmpTelefono> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpTelefonoController(
            IGenericRepository<EmpTelefono> repository,
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
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<EmpTelefonoDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpTelefonoDto>>>> GetAll(
            [FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpTelefonoDto>>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpTelefonoSpecification(
                pagination.Search,
                pagination.PageIndex,
                pagination.PageSize);

            var countSpecification = new EmpTelefonoCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);
            var dto = _mapper.Map<IReadOnlyList<EmpTelefonoDto>>(entities);

            var response = new ResponseWrapper<PagedResponse<EmpTelefonoDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpTelefonoDto>
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
            Summary = "Consultar telefono por Id",
            Description = "Obtiene un telefono de empleado por su identificador."
        )]

        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpTelefonoDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<EmpTelefonoDto>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpTelefonoSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpTelefonoDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el telefono solicitado.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<EmpTelefonoDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpTelefonoDto>(entity)
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
        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<EmpTelefonoDto>>> Create(
            [FromBody] RequestWrapper<EmpTelefonoCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpTelefonoDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpTelefono>(request.Body);

            _repository.Add(entity);
            await _repository.SaveAllAsync();

            InvalidateListCache();

            var response = new ResponseWrapper<EmpTelefonoDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Telefono creado correctamente.",
                Data = _mapper.Map<EmpTelefonoDto>(entity)
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
        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpTelefonoDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpTelefonoDto>>> UpdateById(
            int id,
            [FromBody] RequestWrapper<EmpTelefonoUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpTelefonoDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new EmpTelefonoSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpTelefonoDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el telefono solicitado.",
                    Data = null
                });
            }

            entity.StrNumeroFijo = request.Body.StrNumeroFijo;
            entity.StrNumeroCelular = request.Body.StrNumeroCelular;
            entity.IdEmpEmpleado = request.Body.IdEmpEmpleado;

            _repository.Update(entity);
            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpTelefonoDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Telefono actualizado correctamente.",
                Data = _mapper.Map<EmpTelefonoDto>(entity)
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
            var specification = new EmpTelefonoSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el telefono solicitado.",
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
                Message = "Telefono eliminado correctamente.",
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
