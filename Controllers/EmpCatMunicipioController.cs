using AutoMapper;
using Cavex.Principal.API.Dtos.EmpCatMunicipio;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpCatMunicipio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    /// <summary>
    /// Expone endpoints CRUD para administrar registros de EmpCatMunicipio.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpCatMunicipioController : ControllerBase
    {
        private const string CachePrefix = "EmpCatMunicipio";
        private readonly IGenericRepository<EmpCatMunicipio> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpCatMunicipioController(
            IGenericRepository<EmpCatMunicipio> repository,
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
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpCatMunicipioDto>>>> GetAll([FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpCatMunicipioDto>>? cachedResponse))
                return Ok(cachedResponse);

            var specification = new EmpCatMunicipioSpecification(pagination.Search, pagination.PageIndex, pagination.PageSize);
            var countSpecification = new EmpCatMunicipioCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);

            var response = new ResponseWrapper<PagedResponse<EmpCatMunicipioDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpCatMunicipioDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = _mapper.Map<IReadOnlyList<EmpCatMunicipioDto>>(entities)
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
        public async Task<ActionResult<ResponseWrapper<EmpCatMunicipioDto>>> GetById(int id)
        {
            var entity = await _repository.GetEntityWithSpec(new EmpCatMunicipioSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatMunicipioDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el municipio solicitado.",
                    Data = null
                });
            }

            return Ok(new ResponseWrapper<EmpCatMunicipioDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpCatMunicipioDto>(entity)
            });
        }

        /// <summary>
        /// Crea un nuevo registro.
        /// </summary>
        /// <param name="request">Cuerpo de la solicitud con los datos validados por el contrato de entrada.</param>
        /// <returns>Registro creado con su informacion persistida.</returns>
        [HttpPost]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<EmpCatMunicipioDto>>> Create([FromBody] RequestWrapper<EmpCatMunicipioCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatMunicipioDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpCatMunicipio>(request.Body);

            _repository.Add(entity);
            await _repository.SaveAllAsync();

            InvalidateListCache();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, new ResponseWrapper<EmpCatMunicipioDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Municipio creado correctamente.",
                Data = _mapper.Map<EmpCatMunicipioDto>(entity)
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
        public async Task<ActionResult<ResponseWrapper<EmpCatMunicipioDto>>> UpdateById(int id, [FromBody] RequestWrapper<EmpCatMunicipioUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpCatMunicipioDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = await _repository.GetEntityWithSpec(new EmpCatMunicipioSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpCatMunicipioDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el municipio solicitado.",
                    Data = null
                });
            }

            entity.StrValor = request.Body.StrValor;
            entity.StrDescripcion = request.Body.StrDescripcion;
            entity.IdEmpCatEntidadFederativa = request.Body.IdEmpCatEntidadFederativa;

            _repository.Update(entity);
            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpCatMunicipioDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Municipio actualizado correctamente.",
                Data = _mapper.Map<EmpCatMunicipioDto>(entity)
            });
        }

        /// <summary>
        /// Elimina un registro existente por su identificador.
        /// </summary>
        /// <param name="id">Identificador unico del registro.</param>
        /// <returns>Resultado de la eliminacion solicitada.</returns>
        [HttpDelete("{id:int}")]
        [EnableRateLimiting("CatalogWritePolicy")]
        public async Task<ActionResult<ResponseWrapper<bool>>> Delete(int id)
        {
            var entity = await _repository.GetEntityWithSpec(new EmpCatMunicipioSpecification(id));

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el municipio solicitado.",
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
                Message = "Municipio eliminado correctamente.",
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
