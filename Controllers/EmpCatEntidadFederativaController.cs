using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatEntidadFederativa;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpCatEntidadFederativa;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpCatEntidadFederativaController : ControllerBase
    {
        private const string CachePrefix = "EmpCatEntidadFederativa";
        private readonly IGenericRepository<EmpCatEntidadFederativa> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpCatEntidadFederativaController(
            IGenericRepository<EmpCatEntidadFederativa> repository,
            IMapper mapper,
            IMemoryCache cache)
        {
            _repository = repository;
            _mapper = mapper;
            _cache = cache;
        }

        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpCatEntidadFederativaDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpCatEntidadFederativaDto>>? cachedResponse))
                return Ok(cachedResponse);

            var specification = new EmpCatEntidadFederativaSpecification(pagination.Search, pagination.PageIndex, pagination.PageSize);
            var countSpecification = new EmpCatEntidadFederativaCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);

            var response = new ResponseWrapper<PagedResponse<EmpCatEntidadFederativaDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpCatEntidadFederativaDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = _mapper.Map<IReadOnlyList<EmpCatEntidadFederativaDto>>(entities)
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
        public async Task<ActionResult<ResponseWrapper<EmpCatEntidadFederativaDto>>> GetById(int id)
        {
            var entity = await _repository.GetEntityWithSpec(new EmpCatEntidadFederativaSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatEntidadFederativaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la entidad federativa solicitada.",
                    Data = null
                });
            }

            return Ok(new ResponseWrapper<EmpCatEntidadFederativaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpCatEntidadFederativaDto>(entity)
            });
        }

        [HttpPost]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<EmpCatEntidadFederativaDto>>> Create([FromBody] RequestWrapper<EmpCatEntidadFederativaCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatEntidadFederativaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpCatEntidadFederativa>(request.Body);

            _repository.Add(entity);
            await _repository.SaveAllAsync();

            InvalidateListCache();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, new ResponseWrapper<EmpCatEntidadFederativaDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Entidad federativa creada correctamente.",
                Data = _mapper.Map<EmpCatEntidadFederativaDto>(entity)
            });
        }

        [HttpPut("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<EmpCatEntidadFederativaDto>>> UpdateById(int id, [FromBody] RequestWrapper<EmpCatEntidadFederativaUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatEntidadFederativaDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = await _repository.GetEntityWithSpec(new EmpCatEntidadFederativaSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatEntidadFederativaDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la entidad federativa solicitada.",
                    Data = null
                });
            }

            entity.StrValor = request.Body.StrValor;
            entity.StrDescripcion = request.Body.StrDescripcion;
            entity.IdEmpCatPais = request.Body.IdEmpCatPais;

            _repository.Update(entity);
            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpCatEntidadFederativaDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Entidad federativa actualizada correctamente.",
                Data = _mapper.Map<EmpCatEntidadFederativaDto>(entity)
            });
        }

        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var entity = await _repository.GetEntityWithSpec(new EmpCatEntidadFederativaSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro la entidad federativa solicitada.",
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
                Message = "Entidad federativa eliminada correctamente.",
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