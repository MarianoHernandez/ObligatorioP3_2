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

        public MantenimientoController(IAltaMantenimiento cuAltaMantenimiento, IFindByDate cuFindByDate, IFindByCabania cuFindByCabania, IListadoMantenimiento cuListadoMantenimiento)
        {
            CUaltaMantenimiento = cuAltaMantenimiento;
            CUfindByDate = cuFindByDate;
            CUfindByCabania = cuFindByCabania;
            CUlistadoMantenimiento = cuListadoMantenimiento;
        }

        // GET: api/<MantenimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<MantenimientoDTO> mantenimiento = CUlistadoMantenimiento.ListadoAllMantenimientos();
            return Ok(mantenimiento);
        }

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

        // POST api/<MantenimientoController>
        [HttpPost]
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
            catch
            {
                return StatusCode(500, "Ocurrión un error, no se pudo realizar el alta.");
            }

            return CreatedAtRoute("FindById", new { id = mantenimiento.Id }, mantenimiento);
        }

        [HttpPost("busquedaPorFecha/{f1},{f2}")]
        public IActionResult FindByDate(DateTime f1, DateTime f2)
        {
            if (f1 == null || f2 == null) return BadRequest("Las fechas no son validas");
            try
            {
                IEnumerable<MantenimientoDTO> mantenimientos = CUfindByDate.FindByDateMantenimiento(f1, f2);
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

        //// PUT api/<MantenimientoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] MantenimientoDTO? mantenimiento)
        //{
        //    return View();
        //}

        ////DELETE api/<MantenimientoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //    return View();
        //}
    }

}
