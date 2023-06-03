using Aplicacion.AplicacionesCabaña;
using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.ValueObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CabaniaControllerApi : ControllerBase
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IListadoCabania ListadoCabania { get; set; }
        IBusquedaConFiltros BusquedaConFiltros { get; set; }
        IWebHostEnvironment Env { get; set; }
        IValidarSession ValidarLogin { get; set; }
        IFindByIdCabania Encontrar { get; set; }
        IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }

        public CabaniaControllerApi(IAltaCabania altaCabania, IFindByIdCabania enco, IListadoTipoCabania listadoTipoCabania, IListadoCabania listadoCabania, IValidarSession validarSession, IObtenerMaxMinDescripcion obtenerMaxMin, IWebHostEnvironment webHostEnvironment, IBusquedaConFiltros busquedaConFiltros)
        {
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
            ListadoCabania = listadoCabania;
            Env = webHostEnvironment;
            BusquedaConFiltros = busquedaConFiltros;
            ValidarLogin = validarSession;
            Encontrar = enco;
            ObtenerMaxMin = obtenerMaxMin;
        }
        // GET: api/<CabaniaControllerApi>
        [HttpGet(Name = "Index")]
        public IActionResult Get() //FINDALL
        {
            IEnumerable<CabaniaDTO> cabanias = ListadoCabania.ListadoAllCabania();
            return Ok(cabanias);
        }


        // GET api/<CabaniaControllerApi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CabaniaControllerApi>
        [HttpPost(Name = "Create")]
        public IActionResult Post([FromBody] CabaniaDTO? cabania)
        {
            if (cabania == null) return BadRequest("No se envió información de cabania");
            try
            {
                AltaCabania.Alta(cabania);
            }
            catch (NombreInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Ocurrión un error, no se pudo realizar el alta.");
            }

            return CreatedAtRoute("FindById", new { id = cabania.Id }, cabania);
        }

        // PUT api/<CabaniaControllerApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CabaniaControllerApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
