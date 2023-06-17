using Aplicacion.AplicacionParametros;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.ExcepcionesPropias;
using PresentacionMVC.DTOs;
using Microsoft.AspNetCore.Authorization;
using Aplicacion.AplicacionesCabania;
using Aplicacion.AplicacionesTipoCabania;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/Parametro")]
    [ApiController]
    public class ParametrosControllerApi : ControllerBase
    {
        IUpdateParametro UpdateParametro { get; set; }
        IObtenerMaxMinDescripcion ObtenerMaxMinDescripcion { get; set; }
        public ParametrosControllerApi(
            IUpdateParametro updateParametro,
            IObtenerMaxMinDescripcion obtenerMaxMin
        )
        {
            ObtenerMaxMinDescripcion = obtenerMaxMin;
            UpdateParametro = updateParametro;
        }

        // GET api/<ParametrosControllerApi>/5
        [HttpGet("{nombre}")]
        public string Get(string nombre)
        {
            return "value";
        }

        // PUT api/<ParametrosControllerApi>/5
        [HttpPut("{nombre}")]
        [Authorize]
        public IActionResult Put(string nombre, [FromBody] DTOParametro param)
        {
            try
            {
                if (nombre == null || param.Nombre != nombre) return BadRequest("No se envió informacion del parametro");

                UpdateParametro.Update(param);
                return Ok();
            }
            catch (DescripcionInvalidaException ex) { 
                
                return BadRequest(ex.Message);

            }catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
