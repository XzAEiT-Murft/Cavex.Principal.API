using Cavex.Principal.API.Dtos.VehiculoListado;
using Cavex.Principal.API.RequestHelpers;
using Cavex.Principal.Common.Transfer;
using Cavex.Principal.Infraestructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Cavex.Principal.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class VehiculoListadoController : ControllerBase
    {
        private readonly CavexContext _context;

        public VehiculoListadoController(CavexContext context)
        {
            _context = context;
        }

        [HttpGet]
        [EnableRateLimiting("CatalogReadPolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<PagedResponse<VehiculoListadoDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ResponseWrapper<PagedResponse<VehiculoListadoDto>>>> GetAll(
            [FromQuery] Pagination pagination,
            [FromQuery] int? idVehCatStatus = null)
        {
            var search = pagination.Search?.Trim();

            var query = _context.VehDatosGenerales
                .AsNoTracking()
                .Where(x =>
                    !idVehCatStatus.HasValue ||
                    x.IdVehCatStatus == idVehCatStatus.Value)
                .Where(x =>
                    string.IsNullOrWhiteSpace(search) ||
                    x.StrPlaca.Contains(search) ||
                    x.StrNumSerie.Contains(search) ||
                    x.StrModelo.Contains(search) ||
                    (x.StrVersion != null && x.StrVersion.Contains(search)) ||
                    (x.VehCatMarcaVehiculo != null && x.VehCatMarcaVehiculo.StrValor.Contains(search)) ||
                    (x.VehCatColor != null && x.VehCatColor.StrValor.Contains(search)) ||
                    (x.VehCatStatus != null && x.VehCatStatus.StrValor.Contains(search)));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(x => x.StrPlaca)
                .Skip((pagination.PageIndex - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(x => new VehiculoListadoDto
                {
                    Id = x.Id,
                    StrPlaca = x.StrPlaca,
                    StrNumSerie = x.StrNumSerie,

                    IdVehCatMarcaVehiculo = x.IdVehCatMarcaVehiculo,
                    StrMarca = x.VehCatMarcaVehiculo != null
                        ? x.VehCatMarcaVehiculo.StrValor
                        : string.Empty,

                    StrModelo = x.StrModelo,
                    IntAnio = x.IntAnio,
                    StrVersion = x.StrVersion,

                    IdVehCatColor = x.IdVehCatColor,
                    StrColor = x.VehCatColor != null
                        ? x.VehCatColor.StrValor
                        : string.Empty,

                    DecKilometrajeActual = x.DecKilometrajeActual,

                    IdVehCatStatus = x.IdVehCatStatus,
                })
                .ToListAsync();

            return Ok(new ResponseWrapper<PagedResponse<VehiculoListadoDto>>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = new PagedResponse<VehiculoListadoDto>
                {
                    PageIndex = pagination.PageIndex,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    Items = items
                }
            });
        }

        [HttpGet("{id:int}")]
        [EnableRateLimiting("CatalogReadPolicy")]
        [ProducesResponseType(typeof(ResponseWrapper<VehiculoListadoDetalleDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseWrapper<VehiculoListadoDetalleDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ResponseWrapper<VehiculoListadoDetalleDto>>> GetById(int id)
        {
            var item = await _context.VehDatosGenerales
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(x => new VehiculoListadoDetalleDto
                {
                    Id = x.Id,
                    StrPlaca = x.StrPlaca,
                    StrNumSerie = x.StrNumSerie,
                    IdVehCatMarcaVehiculo = x.IdVehCatMarcaVehiculo,
                    StrMarca = x.VehCatMarcaVehiculo != null ? x.VehCatMarcaVehiculo.StrValor : string.Empty,
                    StrModelo = x.StrModelo,
                    IntAnio = x.IntAnio,
                    StrVersion = x.StrVersion,
                    IdVehCatColor = x.IdVehCatColor,
                    StrColor = x.VehCatColor != null ? x.VehCatColor.StrValor : string.Empty,
                    DecKilometrajeActual = x.DecKilometrajeActual,
                    IdVehCatStatus = x.IdVehCatStatus,
                    StrStatus = x.VehCatStatus != null ? x.VehCatStatus.StrValor : string.Empty
                })
                .FirstOrDefaultAsync();

            if (item is null)
            {
                return NotFound(new ResponseWrapper<VehiculoListadoDetalleDto>
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Message = "No se encontro el vehiculo solicitado."
                });
            }

            return Ok(new ResponseWrapper<VehiculoListadoDetalleDto>
            {
                StatusCode = HttpStatusCode.OK,
                Message = "Consulta realizada correctamente.",
                Data = item
            });
        }
    }
}
