using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCondicionesLaborales;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpCondicionesLaborales;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpCondicionesLaboralesController : ControllerBase
    {
        private const string CachePrefix = "EmpCondicionesLaborales";
        private readonly IGenericRepository<EmpCondicionesLaborales> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpCondicionesLaboralesController(
            IGenericRepository<EmpCondicionesLaborales> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<EmpCondicionesLaboralesDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpCondicionesLaboralesDto>>>> GetAll(
            [FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpCondicionesLaboralesDto>>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpCondicionesLaboralesSpecification(
                pagination.Search,
                pagination.PageIndex,
                pagination.PageSize);

            var countSpecification = new EmpCondicionesLaboralesCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);
            var dto = _mapper.Map<IReadOnlyList<EmpCondicionesLaboralesDto>>(entities);

            var response = new ResponseWrapper<PagedResponse<EmpCondicionesLaboralesDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpCondicionesLaboralesDto>
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
            Summary = "Consultar condiciones laborales por Id",
            Description = "Obtiene un registro especifico de condiciones laborales mediante su identificador."
        )]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpCondicionesLaboralesDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<EmpCondicionesLaboralesDto>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpCondicionesLaboralesSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCondicionesLaboralesDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontraron las condiciones laborales solicitadas.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<EmpCondicionesLaboralesDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpCondicionesLaboralesDto>(entity)
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

        [HttpPost]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<EmpCondicionesLaboralesDto>>> Create(
            [FromBody] RequestWrapper<EmpCondicionesLaboralesCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCondicionesLaboralesDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpCondicionesLaborales>(request.Body);

            _repository.Add(entity);

            await _repository.SaveAllAsync();

            InvalidateListCache();

            var dto = _mapper.Map<EmpCondicionesLaboralesDto>(entity);

            var response = new ResponseWrapper<EmpCondicionesLaboralesDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Condiciones laborales creadas correctamente.",
                Data = dto
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCondicionesLaboralesDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpCondicionesLaboralesDto>>> UpdateById(
            int id,
            [FromBody] RequestWrapper<EmpCondicionesLaboralesUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCondicionesLaboralesDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new EmpCondicionesLaboralesSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCondicionesLaboralesDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontraron las condiciones laborales solicitadas.",
                    Data = null
                });
            }

            entity.BitCercaniaVivienda = request.Body.BitCercaniaVivienda;
            entity.BitDisponibilidadDeViaje = request.Body.BitDisponibilidadDeViaje;
            entity.MnySueldoMensual = request.Body.MnySueldoMensual;
            entity.BitExperienciaEnArea = request.Body.BitExperienciaEnArea;
            entity.BitDisponibilidadCambioResidencia = request.Body.BitDisponibilidadCambioResidencia;
            entity.DteFechaIngreso = request.Body.DteFechaIngreso;

            _repository.Update(entity);

            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpCondicionesLaboralesDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Condiciones laborales actualizadas correctamente.",
                Data = _mapper.Map<EmpCondicionesLaboralesDto>(entity)
            });
        }

        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var specification = new EmpCondicionesLaboralesSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontraron las condiciones laborales solicitadas.",
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
                Message = "Condiciones laborales eliminadas correctamente.",
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