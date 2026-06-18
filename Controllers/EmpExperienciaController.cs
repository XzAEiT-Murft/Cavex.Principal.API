using AutoMapper;
using Cavex.Principal.API.Dtos.EmpExperiencia;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpExperiencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpExperienciaController : ControllerBase
    {
        private const string CachePrefix = "EmpExperiencia";
        private readonly IGenericRepository<EmpExperiencia> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpExperienciaController(
            IGenericRepository<EmpExperiencia> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<EmpExperienciaDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpExperienciaDto>>>> GetAll(
            [FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpExperienciaDto>>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpExperienciaSpecification(
                pagination.Search,
                pagination.PageIndex,
                pagination.PageSize);

            var countSpecification = new EmpExperienciaCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);
            var dto = _mapper.Map<IReadOnlyList<EmpExperienciaDto>>(entities);

            var response = new ResponseWrapper<PagedResponse<EmpExperienciaDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpExperienciaDto>
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
            Summary = "Consultar experiencia por Id",
            Description = "Obtiene un registro especifico de experiencia laboral mediante su identificador."
        )]
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpExperienciaDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<EmpExperienciaDto>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpExperienciaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpExperienciaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la experiencia solicitada.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<EmpExperienciaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpExperienciaDto>(entity)
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
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<EmpExperienciaDto>>> Create(
            [FromBody] RequestWrapper<EmpExperienciaCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpExperienciaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpExperiencia>(request.Body);

            _repository.Add(entity);

            await _repository.SaveAllAsync();

            InvalidateListCache();

            var dto = _mapper.Map<EmpExperienciaDto>(entity);

            var response = new ResponseWrapper<EmpExperienciaDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Experiencia creada correctamente.",
                Data = dto
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpExperienciaDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpExperienciaDto>>> UpdateById(
            int id,
            [FromBody] RequestWrapper<EmpExperienciaUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpExperienciaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new EmpExperienciaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpExperienciaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la experiencia solicitada.",
                    Data = null
                });
            }

            entity.StrEmpresa = request.Body.StrEmpresa;
            entity.StrPuesto = request.Body.StrPuesto;
            entity.StrArea = request.Body.StrArea;
            entity.DteFechaIncio = request.Body.DteFechaIncio;
            entity.DteFechaFin = request.Body.DteFechaFin;
            entity.MnySueldo = request.Body.MnySueldo;
            entity.StrMotivoSalida = request.Body.StrMotivoSalida;
            entity.IdEmpEmpleado = request.Body.IdEmpEmpleado;

            _repository.Update(entity);

            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpExperienciaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Experiencia actualizada correctamente.",
                Data = _mapper.Map<EmpExperienciaDto>(entity)
            });
        }

        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var specification = new EmpExperienciaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la experiencia solicitada.",
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
                Message = "Experiencia eliminada correctamente.",
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