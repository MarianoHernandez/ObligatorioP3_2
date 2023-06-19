using Microsoft.AspNetCore.Mvc;
using Aplicacion.AplicacionesMantenimientos;
using DTOs;
using Negocio.ExcepcionesPropias;
using PresentacionMVC.Models;
using System.Net.WebSockets;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Aplicacion.AplicacionesCabania;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias.Cabanias;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MantenimientoController : ControllerBase
    {
        IAltaMantenimiento CUaltaMantenimiento { get; set; }
        IFindByDate CUfindByDate { get; set; }
        IFindByCabania CUfindByCabania { get; set; }
        IListadoMantenimiento CUlistadoMantenimiento { get; set; }
        IFindByValues CUfindByValues { get; set; }

        public MantenimientoController(IAltaMantenimiento cuAltaMantenimiento, IFindByDate cuFindByDate, IFindByCabania cuFindByCabania, IListadoMantenimiento cuListadoMantenimiento,
           IFindByValues cuFindByValues )
        {
            CUaltaMantenimiento = cuAltaMantenimiento;
            CUfindByDate = cuFindByDate;
            CUfindByCabania = cuFindByCabania;
            CUlistadoMantenimiento = cuListadoMantenimiento;
            CUfindByValues = cuFindByValues;
        }

        // GET: api/<MantenimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MantenimientoDTO> mantenimiento = CUlistadoMantenimiento.ListadoAllMantenimientos();
            return Ok(mantenimiento);
        }

        // GET api/<MantenimientoController>/5
        [HttpGet("{idCabania}", Name = "FindById")]
        public IActionResult Get(int idCabania)
        {
            if (idCabania <= 0) return BadRequest("El id proporcionado no es válido");
            try
            {
                IEnumerable<MantenimientoDTO> mantenimiento = CUfindByCabania.FindMantenimientoByCabania(idCabania);
                if (mantenimiento == null) return NotFound($"No existe el tema con id: {idCabania}");
                return Ok(mantenimiento);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }

        // POST api/<MantenimientoController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] MantenimientoDTO? mantenimiento)
        {

            if (mantenimiento == null) return BadRequest("No se envió información de mantenimiento");
            try
            {

                CUaltaMantenimiento.Alta(mantenimiento);
            }
            catch (NombreInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (CaracteresDentroDeRango ex)
            {
                return BadRequest(ex.Message);
            }
            catch (MantenimientoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrión un error, no se pudo realizar el alta.");
            }

            return CreatedAtRoute("FindById", new { id = mantenimiento.Id }, mantenimiento);
        }

        [HttpGet("busquedaPorFecha")]
        [Authorize]
        public IActionResult FindByDate([FromQuery] string f1, string f2)
        {
            if (f1 == null || f2 == null) return BadRequest("Las fechas no son validas");
            try
            {
                DateTime dateTime = DateTime.Parse(f1);
                DateTime dateTime2 = DateTime.Parse(f2);
                IEnumerable<MantenimientoDTO> mantenimientos = CUfindByDate.FindByDateMantenimiento(dateTime, dateTime2);
                return Ok(mantenimientos);
            }
            catch (MantenimientoInvalidoException ex)
            {

                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrión un error, no se pudo encontrar los mantenimientos.");
            }
        }

        [HttpGet("busquedaPorValores")]
        [Authorize]
        public IActionResult MantenimientosPorValores([FromQuery] int c1, int c2, string nombreEmpleado)
        {
            if (c1 == null || c2 == null) return BadRequest("Los costos no son validas");
            try
            {
                IEnumerable<MantenimientoDTO> mantenimientos = CUfindByValues.MantenimientosPorValores(c1, c2, nombreEmpleado);
                return Ok(mantenimientos);
            }
            catch (MantenimientoInvalidoException ex)
            {

                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrión un error, no se pudo encontrar los mantenimientos.");
            }
        }

    }

}
