using Aplicacion.AplicacionesCabania;
using Aplicacion.AplicacionesTipoCabaña;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;

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
        IFindByIdCabania FindByIdCabania { get; set; }
        IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }
        IFindByIdTipo FindTipoById {get; set;}

        public CabaniaControllerApi(
            IFindByIdTipo findByIdTipo,
            IAltaCabania altaCabania, 
            IFindByIdCabania findByIdCabania, 
            IListadoTipoCabania listadoTipoCabania, 
            IListadoCabania listadoCabania, 
            IBusquedaConFiltros busquedaConFiltros)
        {
            
            AltaCabania = altaCabania;
            ListadoTipoCabania = listadoTipoCabania;
            ListadoCabania = listadoCabania;
            BusquedaConFiltros = busquedaConFiltros;
            FindByIdCabania = findByIdCabania;
            FindTipoById =findByIdTipo;
        }
        // GET: api/<CabaniaControllerApi>
        [HttpGet("index", Name = "Index")]
        public IActionResult Get() //FINDALL
        {
            IEnumerable<CabaniaDTO> cabanias = ListadoCabania.ListadoAllCabania();
            return Ok(cabanias);
        }


        // GET api/<CabaniaControllerApi>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Cabania cab = FindByIdCabania.FindById(id);
                return Ok(cab);
            }
            catch (NoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<CabaniaControllerApi>
        [HttpPost]
        public IActionResult Post([FromBody] CabaniaDTO? cabania)
        {
            if (cabania == null) return BadRequest("No se envió información de cabania");
            try
            {
                TipoCabania tipo = FindTipoById.FindOneById(cabania.TipoCabaniaId);
                AltaCabania.Alta(cabania, tipo);
            }
            catch (NombreInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoEncontradoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return CreatedAtRoute("Get", new { id = cabania.Id }, cabania);
        }

        // GET api/<CabaniaControllerApi>
        [HttpGet("MostrerFiltradas")]
        public IActionResult MostrerFiltradas([FromQuery] string Nombre, int TipoID, int CantidadPersonas, bool Habilitada)
        {
            IEnumerable<CabaniaDTO> filtradas = BusquedaConFiltros.GetCabanias(Nombre, TipoID, CantidadPersonas, Habilitada);
            return Ok(filtradas);
        }

    }
}
