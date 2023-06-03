using Microsoft.AspNetCore.Mvc;
using Aplicacion.AplicacionesMantenimientos;
using DTOs;
using Negocio.ExcepcionesPropias;

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

        public MantenimientoController (IAltaMantenimiento cuAltaMantenimiento, IFindByDate cuFindByDate, IFindByCabania cuFindByCabania, IListadoMantenimiento cuListadoMantenimiento)
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MantenimientoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MantenimientoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MantenimientoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
