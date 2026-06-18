using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatPais;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpCatPais;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpCatPaisController : ControllerBase
    {
        private const string CachePrefix = "EmpCatPais";
        private readonly IGenericRepository<EmpCatPais> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpCatPaisController(
            IGenericRepository<EmpCatPais> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpCatPaisDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpCatPaisDto>>? cachedResponse))
                return Ok(cachedResponse);

            var specification = new EmpCatPaisSpecification(pagination.Search, pagination.PageIndex, pagination.PageSize);
            var countSpecification = new EmpCatPaisCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);

            var response = new ResponseWrapper<PagedResponse<EmpCatPaisDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpCatPaisDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = _mapper.Map<IReadOnlyList<EmpCatPaisDto>>(entities)
                }
            };

            _cache.Set(cacheKey, response, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            });

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        [EnableRateLimiting("CatalogReadPolicy")]
        public async Task<ActionResult<ResponseWrapper<EmpCatPaisDto>>> GetById(int id)
        {
            var entity = await _repository.GetEntityWithSpec(new EmpCatPaisSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatPaisDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el pais solicitado.",
                    Data = null
                });
            }

            return Ok(new ResponseWrapper<EmpCatPaisDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpCatPaisDto>(entity)
            });
        }

        [HttpPost]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<EmpCatPaisDto>>> Create([FromBody] RequestWrapper<EmpCatPaisCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatPaisDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpCatPais>(request.Body);

            _repository.Add(entity);
            await _repository.SaveAllAsync();

            InvalidateListCache();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, new ResponseWrapper<EmpCatPaisDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Pais creado correctamente.",
                Data = _mapper.Map<EmpCatPaisDto>(entity)
            });
        }

        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<EmpCatPaisDto>>> UpdateById(int id, [FromBody] RequestWrapper<EmpCatPaisUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatPaisDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = await _repository.GetEntityWithSpec(new EmpCatPaisSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatPaisDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el pais solicitado.",
                    Data = null
                });
            }

            entity.StrValor = request.Body.StrValor;
            entity.StrDescripcion = request.Body.StrDescripcion;

            _repository.Update(entity);
            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpCatPaisDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Pais actualizado correctamente.",
                Data = _mapper.Map<EmpCatPaisDto>(entity)
            });
        }

        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var entity = await _repository.GetEntityWithSpec(new EmpCatPaisSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el pais solicitado.",
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
                Message = "Pais eliminado correctamente.",
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