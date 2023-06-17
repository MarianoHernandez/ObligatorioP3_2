﻿using Aplicacion.AplicacionesCabania;
using Aplicacion.AplicacionesTipoCabania;
using Aplicacion.AplicacionesUsuario;
using Aplicacion.AplicacionParametros;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.ExcepcionesPropias.Cabanias;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CabaniaControllerApi : ControllerBase
    {
        IAltaCabania AltaCabania { get; set; }
        IListadoCabania ListadoCabania { get; set; }
        IBusquedaConFiltros BusquedaConFiltros { get; set; }
        IFindByIdCabania FindByIdCabania { get; set; }
        IFindByIdTipo FindTipoById {get; set;}
        IFiltroPrecio FiltroPrecio { get; set; }

        public CabaniaControllerApi(
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

        // GET: api/<CabaniaControllerApi>
        [HttpGet("health")]
        public IActionResult GetHealth() //FINDALL
        {
            return Ok(true);
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
                CabaniaDTO cab = FindByIdCabania.FindById(id);
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
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok( cabania);
        }

        // GET api/<CabaniaControllerApi>
        [HttpGet("MostrerFiltradas")]
        public IActionResult MostrerFiltradas([FromQuery] string? Nombre, int? TipoID, int? CantidadPersonas, bool? Habilitada)
        {
            IEnumerable<CabaniaDTO> filtradas = BusquedaConFiltros.GetCabanias(Nombre, TipoID, CantidadPersonas, Habilitada);
            return Ok(filtradas);
        }

        [HttpGet("PrecioFiltro")]
        public IActionResult PrecioFiltradas([FromQuery] decimal costo, int tipoId)
        {
            if (costo == null) return BadRequest("No se envió información de cabania");
            try
            {
                IEnumerable<CabaniaDTO> filtradas = FiltroPrecio.Filtro(costo, tipoId);
                return Ok(filtradas);
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

        }


    }
}
