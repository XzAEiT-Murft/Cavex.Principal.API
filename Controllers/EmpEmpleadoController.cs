using AutoMapper;
using Cavex.Principal.API.Dtos.EmpEmpleado;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Core.Contract;
using Cavex.Principal.Core.Entities;
using Cavex.Principal.Core.Specifications.EmpEmpleado;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Caching.Memory;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    /// <summary>
    /// Expone endpoints CRUD para administrar registros de EmpEmpleado.
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpEmpleadoController : ControllerBase
    {
        private const string CachePrefix = "EmpEmpleado";
        private readonly IGenericRepository<EmpEmpleado> _repository;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private static int _listCacheVersion = 1;

        public EmpEmpleadoController(
            IGenericRepository<EmpEmpleado> repository,
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
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<EmpEmpleadoDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<EmpEmpleadoDto>>>> GetAll(
            [FromQuery] Pagination pagination)
        {
            var cacheKey = $"{CachePrefix}:List:Version={_listCacheVersion}:PageIndex={pagination.PageIndex}:PageSize={pagination.PageSize}:Search={pagination.Search}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<PagedResponse<EmpEmpleadoDto>>? cachedResponse))
                return Ok(cachedResponse);

            var specification = new EmpEmpleadoSpecification(pagination.Search, pagination.PageIndex, pagination.PageSize);
            var countSpecification = new EmpEmpleadoCountSpecification(pagination.Search);

            var entities = await _repository.ListAsync(specification);
            var totalCount = await _repository.CountAsync(countSpecification);

            var response = new ResponseWrapper<PagedResponse<EmpEmpleadoDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<EmpEmpleadoDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = _mapper.Map<IReadOnlyList<EmpEmpleadoDto>>(entities)
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
        [SwaggerOperation(Summary = "Consultar empleado por Id")]
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpEmpleadoDto>>> GetById(int id)
        {
            var cacheKey = $"{CachePrefix}:Id:{id}";

            if (_cache.TryGetValue(cacheKey, out ResponseWrapper<EmpEmpleadoDto>? cachedResponse))
                return Ok(cachedResponse);

            var specification = new EmpEmpleadoSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpEmpleadoDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el empleado solicitado.",
                    Data = null
                });
            }

            var response = new ResponseWrapper<EmpEmpleadoDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = _mapper.Map<EmpEmpleadoDto>(entity)
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
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseWrapper<EmpEmpleadoDto>>> Create(
            [FromBody] RequestWrapper<EmpEmpleadoCreateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpEmpleadoDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var entity = _mapper.Map<EmpEmpleado>(request.Body);

            _repository.Add(entity);
            await _repository.SaveAllAsync();

            InvalidateListCache();

            var response = new ResponseWrapper<EmpEmpleadoDto>
            {
                StatusCode = HttpStatusCode.Created,
                Message = "Empleado creado correctamente.",
                Data = _mapper.Map<EmpEmpleadoDto>(entity)
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
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ResponseWrapper<EmpEmpleadoDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<EmpEmpleadoDto>>> UpdateById(
            int id,
            [FromBody] RequestWrapper<EmpEmpleadoUpdateDto> request)
        {
            if (request.Body is null)
            {
                return BadRequest(new ResponseWrapper<EmpEmpleadoDto>
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "El cuerpo de la solicitud es requerido.",
                    Data = null
                });
            }

            var specification = new EmpEmpleadoSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<EmpEmpleadoDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el empleado solicitado.",
                    Data = null
                });
            }

            entity.StrNombre = request.Body.StrNombre;
            entity.StrApellidoPaterno = request.Body.StrApellidoPaterno;
            entity.StrApellidoMaterno = request.Body.StrApellidoMaterno;
            entity.DteFechaNacimiento = request.Body.DteFechaNacimiento;
            entity.StrRfc = request.Body.StrRfc;
            entity.StrCurp = request.Body.StrCurp;
            entity.IntEdad = request.Body.IntEdad;
            entity.StrCorreoElectronico = request.Body.StrCorreoElectronico;
            entity.BigNss = request.Body.BigNss;
            entity.IntNss = request.Body.BigNss;
            entity.IdEmpCatGenero = request.Body.IdEmpCatGenero;
            entity.IdEmpCatEstadoCivil = request.Body.IdEmpCatEstadoCivil;
            entity.IdEmpCatNacionalidad = request.Body.IdEmpCatNacionalidad;
            entity.IdEmpCatTipoContratacion = request.Body.IdEmpCatTipoContratacion;
            entity.IdEmpDireccion = request.Body.IdEmpDireccion;
            entity.IdEmpDatosAcademicos = request.Body.IdEmpDatosAcademicos;
            entity.IdEmpDocumentosLaborales = request.Body.IdEmpDocumentosLaborales;
            entity.IdEmpCondicionesLaborales = request.Body.IdEmpCondicionesLaborales;
            entity.IdCatStatus = request.Body.IdCatStatus;

            _repository.Update(entity);
            await _repository.SaveAllAsync();

            InvalidateEntityCache(id);
            InvalidateListCache();

            return Ok(new ResponseWrapper<EmpEmpleadoDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Empleado actualizado correctamente.",
                Data = _mapper.Map<EmpEmpleadoDto>(entity)
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
            var specification = new EmpEmpleadoSpecification(id);
            var entity = await _repository.GetEntityWithSpec(specification);

            if (entity is null)
            {
                return NotFound(new ResponseWrapper<bool>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el empleado solicitado.",
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
                Message = "Empleado eliminado correctamente.",
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
