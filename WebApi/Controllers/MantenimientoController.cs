using Microsoft.AspNetCore.Mvc;
using Aplicacion.AplicacionesMantenimientos;
using DTOs;
using Negocio.ExcepcionesPropias;
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

        /// <summary>
        /// Muestra todos los mantenimientos
        /// </summary>
        /// <returns></returns>

        // GET: api/<MantenimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MantenimientoDTO> mantenimiento = CUlistadoMantenimiento.ListadoAllMantenimientos();
            return Ok(mantenimiento);
        }

        /// <summary>
        /// Busca el mantenimiento por el id de la cabaña
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<MantenimientoController>/5
        [HttpGet("{id}", Name = "FindById")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("El id proporcionado no es válido");
            try
            {
                IEnumerable<MantenimientoDTO> mantenimiento = CUfindByCabania.FindMantenimientoByCabania(id);
                if (mantenimiento == null) return NotFound($"No existe el tema con id: {id}");
                return Ok(mantenimiento);
            }
            catch
            {
                return StatusCode(500, "Ocurrió un error inesperado");
            }
        }


        /// <summary>
        /// Crea el mantenimiento
        /// </summary>
        /// <param name="mantenimiento"></param>
        /// <returns></returns>

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
                return NotFound(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrión un error, no se pudo realizar el alta.");
            }

            return CreatedAtRoute("", mantenimiento);
        }


        /// <summary>
        /// Busca mantenimiento entre dos fechas
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="f2"></param>
        /// <returns></returns>

        [HttpGet("busquedaPorFecha")]
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

        /// <summary>
        /// Busca el mantenimiento entre dos costos y por empleado
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        /// <param name="nombreEmpleado"></param>
        /// <returns></returns>

        [HttpGet("busquedaPorValores")]
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
