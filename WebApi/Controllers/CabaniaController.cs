using Aplicacion.AplicacionesCabania;
using Aplicacion.AplicacionesTipoCabania;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/Cabania")]
    [ApiController]
    public class CabaniaController : ControllerBase
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoCabania ListadoCabania { get; set; }
        IBusquedaConFiltros BusquedaConFiltros { get; set; }
        IFindByIdCabania FindByIdCabania { get; set; }
        IFindByIdTipo FindTipoById {get; set;}
        IFiltroPrecio FiltroPrecio { get; set; }

        public CabaniaController(
            IFindByIdTipo findByIdTipo,
            IAltaCabania altaCabania, 
            IFindByIdCabania findByIdCabania, 
            IListadoCabania listadoCabania, 
            IBusquedaConFiltros busquedaConFiltros,
            IFiltroPrecio filtroPrecio)
        {
            
            AltaCabania = altaCabania;
            ListadoCabania = listadoCabania;
            BusquedaConFiltros = busquedaConFiltros;
            FindByIdCabania = findByIdCabania;
            FindTipoById =findByIdTipo;
            FiltroPrecio = filtroPrecio;
        }


        /// <summary>
        /// Muestra todas las cabañas
        /// </summary>
        /// <returns></returns>
        /// 

        // GET: api/<CabaniaControllerApi>
        [HttpGet("index", Name = "Index")]
        public IActionResult Get() //FINDALL
        {
            IEnumerable<CabaniaDTO> cabanias = ListadoCabania.ListadoAllCabania();
            return Ok(cabanias);
        }

        /// <summary>
        /// Busca la cabaña por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<CabaniaControllerApi>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                CabaniaDTO cab = FindByIdCabania.FindById(id);
                return Ok(cab);
            }
            catch (NoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Crea la cabaña
        /// </summary>
        /// <param name="cabania"></param>
        /// <returns></returns>

        // POST api/<CabaniaControllerApi>
        [HttpPost]
        [Authorize]
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
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException)
                {
                    SqlException sql = (SqlException)ex.InnerException;
                    if (sql.Number == 2601)
                    {
                        return BadRequest("El nombre ingresado ya existe.");
                    }

                }
                return StatusCode(500, ex.Message);
            }

            return Ok(cabania);
        }

        /// <summary>
        /// Busca la cabaña filtradas
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="TipoID"></param>
        /// <param name="CantidadPersonas"></param>
        /// <param name="Habilitada"></param>
        /// <returns></returns>

        // GET api/<CabaniaControllerApi>
        [HttpGet("MostrerFiltradas")]
        public IActionResult MostrerFiltradas([FromQuery] string? Nombre, int? TipoID, int? CantidadPersonas, bool? Habilitada)
        {
            IEnumerable<CabaniaDTO> filtradas = BusquedaConFiltros.GetCabanias(Nombre, TipoID, CantidadPersonas, Habilitada);
            return Ok(filtradas);
        }

        /// <summary>
        /// Busca la cabaña por costo
        /// </summary>
        /// <param name="costo"></param>
        /// <returns></returns>

        [HttpGet("PrecioFiltro")]
        public IActionResult PrecioFiltradas([FromQuery] decimal costo)
        {
            if (costo == null) return BadRequest("No se envió información de cabania");
            try
            {
                IEnumerable<CabaniaDTO> filtradas = FiltroPrecio.Filtro(costo);
                return Ok(filtradas);
            }
            catch (NombreInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }


    }
}
