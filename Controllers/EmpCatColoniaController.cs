using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatColonia;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpCatColonia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpCatColoniaController : ControllerBase
    {
        private const string CachePrefix = "EmpCatColonia";
        private readonly IGenericRepository<EmpCatColonia> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpCatColoniaController(
            IGenericRepository<EmpCatColonia> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<EmpCatColoniaDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpCatColoniaDto>>>> GetAll(
            [FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpCatColoniaDto>>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpCatColoniaSpecification(
                pagination.Search,
                pagination.PageIndex,
                pagination.PageSize);

            var countSpecification = new EmpCatColoniaCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);

            var response = new ResponseWrapper<PagedResponse<EmpCatColoniaDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpCatColoniaDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = _mapper.Map<IReadOnlyList<EmpCatColoniaDto>>(entities)
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
            Summary = "Consultar colonia por Id",
            Description = "Obtiene una colonia por su identificador."
        )]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpCatColoniaDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<EmpCatColoniaDto>? cachedResponse))
            {
                return Ok(cachedResponse);
            }

            var specification = new EmpCatColoniaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatColoniaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la colonia solicitada.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<EmpCatColoniaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpCatColoniaDto>(entity)
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
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<EmpCatColoniaDto>>> Create(
            [FromBody] RequestWrapper<EmpCatColoniaCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatColoniaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpCatColonia>(request.Body);

            _repository.Add(entity);
            await _repository.SaveAllAsync();

            InvalidateListCache();

            var response = new ResponseWrapper<EmpCatColoniaDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Colonia creada correctamente.",
                Data = _mapper.Map<EmpCatColoniaDto>(entity)
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpCatColoniaDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpCatColoniaDto>>> UpdateById(
            int id,
            [FromBody] RequestWrapper<EmpCatColoniaUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatColoniaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new EmpCatColoniaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatColoniaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la colonia solicitada.",
                    Data = null
                });
            }

            entity.StrValor = request.Body.StrValor;
            entity.StrDescripcion = request.Body.StrDescripcion;
            entity.IntCodigoPostal = request.Body.IntCodigoPostal;
            entity.StrTipoAsentamiento = request.Body.StrTipoAsentamiento;
            entity.IntEmpCatMunicipio = request.Body.IntEmpCatMunicipio;

            _repository.Update(entity);
            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpCatColoniaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Colonia actualizada correctamente.",
                Data = _mapper.Map<EmpCatColoniaDto>(entity)
            });
        }

        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<bool>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var specification = new EmpCatColoniaSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la colonia solicitada.",
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
                Message = "Colonia eliminada correctamente.",
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
