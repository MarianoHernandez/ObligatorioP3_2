using Aplicacion.AplicacionesCabania;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.ExcepcionesPropias;
using Aplicacion.AplicacionesTipoCabania;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCabaniaControllerApi : ControllerBase
    {
        IAltaTipoCabania AltaTipoCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }




        public TipoCabaniaControllerApi( IAltaTipoCabania altaTipoCabania, IListadoTipoCabania listadoTipoCabania)
        {
            AltaTipoCabania = altaTipoCabania;
            ListadoTipoCabania = listadoTipoCabania;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TipoCabaniaDTO> tipos = ListadoTipoCabania.ObtenerListado();
            return Ok(tipos);

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IActionResult Post([FromBody] TipoCabaniaDTO tipo)
        {
            if (tipo == null) return BadRequest("No se envió información de cabania");
            try
            {
                AltaTipoCabania.Alta(tipo);
            }
            catch (DescripcionInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok(tipo);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
