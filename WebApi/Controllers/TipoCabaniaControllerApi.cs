using Aplicacion.AplicacionesCabania;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.ExcepcionesPropias;
using Aplicacion.AplicacionesTipoCabania;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/TipoCabania")]
    [ApiController]
    public class TipoCabaniaControllerApi : ControllerBase
    {
        IAltaTipoCabania AltaTipoCabania { get; set; }
        IListadoTipoCabania ListadoTipoCabania { get; set; }
        IFindByName FindByName { get; set; }
        IDeleteTipo DeleteTipo { get; set; }
        IUpdateTipo UpdateTipo { get; set; }
        IFindCabaniaPorTipo FindCabaniaPorTipo { get; set; }



        public TipoCabaniaControllerApi( 
            IAltaTipoCabania altaTipoCabania, 
            IListadoTipoCabania listadoTipoCabania, 
            IFindByName findByName,
            IDeleteTipo deleteTipo,
            IUpdateTipo updateTip,
            IFindCabaniaPorTipo findCabaniaPorTipo)
        {
            AltaTipoCabania = altaTipoCabania;
            ListadoTipoCabania = listadoTipoCabania;
            FindByName = findByName;
            DeleteTipo = deleteTipo;
            UpdateTipo = updateTip;
            FindCabaniaPorTipo = findCabaniaPorTipo;

        }
    
        /// <summary>
        /// Muestra todos los tipos de cabaña
        /// </summary>
        /// <returns></returns>

        // GET: api/<ValuesController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<TipoCabaniaDTO> tipos = ListadoTipoCabania.ObtenerListado();
            return Ok(tipos);

        }

        /// <summary>
        /// Busca el tipo de cabaña por el nombre
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>

        [HttpGet("FindByName", Name = "BusquedaNombre")]
        public IActionResult GetNombre([FromQuery] string nombre)
        {
            if (nombre == null) return BadRequest("No se envió informacion del tipo");

            try
            {
                TipoCabaniaDTO tipo = FindByName.FindOne(nombre);
                return Ok(tipo);
            }catch(NoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) {

                return StatusCode(500, ex.Message);
            }

        }

        /// <summary>
        /// Busca el tipo de cabaña por el id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // GET api/<ValuesController>/5
        [HttpGet("{id}", Name = "BusquedaId")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Crea el tipo de cabaña
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>

        // POST api/<ValuesController>
        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] TipoCabaniaDTO tipo)
        {
            if (tipo == null) return BadRequest("No se envió informacion del tipo");
            try
            {
                AltaTipoCabania.Alta(tipo);
            }
            catch (DescripcionInvalidaException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NoEncontradoException ex)
            {
                return StatusCode(501,ex.Message);
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

            return Ok(tipo);
        }

        /// <summary>
        /// Modifica el tipo de cabaña
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tipo"></param>
        /// <returns></returns>

        // PUT api/<ValuesController>/5
        [HttpPut("{nombre}")]
        [Authorize]
        public IActionResult Put(string nombre, [FromBody] TipoCabaniaDTO? tipo)
        {
            if (nombre == null || tipo == null || tipo.Nombre != nombre) return BadRequest("Los datos proporcionados no son válidos");
            try
            {
                UpdateTipo.Update(tipo);
            }
            catch (NombreInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
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

            return Ok(tipo);

        }

        /// <summary>
        /// Borra el tipo de cabaña
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        /// <exception cref="ExisteOtroElementoRelacionado"></exception>

        // DELETE api/<ValuesController>/5
        [HttpDelete("{nombre}",Name = "Borrar")]
        [Authorize]
        public IActionResult Delete(string nombre)
        {
            try
            {
                TipoCabaniaDTO tipo = FindByName.FindOne(nombre);
                IEnumerable<Cabania> cabanias = FindCabaniaPorTipo.FindByTipoCabania(nombre);
                if (cabanias.Count() != 0) throw new ExisteOtroElementoRelacionado("No se puede eliminar el Tipo ya que hay cabanias registradas con el tipo");
                DeleteTipo.DeleteTipo(nombre);
                return Ok(tipo);
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
