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
        public ParametrosControllerApi(
            IUpdateParametro updateParametro,
            IObtenerMaxMinDescripcion obtenerMaxMin
        )
        {
            UpdateParametro = updateParametro;
        }

        /// <summary>
        /// Ingresa el parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>

        // GET api/<ParametrosControllerApi>/5
        [HttpGet("{nombre}")]
        public string Get(string nombre)
        {
            return "value";
        }


        /// <summary>
        /// Modifica ese parametro
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="param"></param>
        /// <returns></returns>

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
