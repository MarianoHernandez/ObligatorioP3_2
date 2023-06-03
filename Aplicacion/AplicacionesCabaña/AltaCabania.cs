using Aplicacion.AplicacionParametros;
using DTOs;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Aplicacion.AplicacionesCabaña
{
    public class AltaCabania : IAltaCabania
    {
        public IRepositorioCabania Repo { get; set; }
        public IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }

        public AltaCabania(IRepositorioCabania repo, IObtenerMaxMinDescripcion obtenerMaxMin)
        {

            Repo = repo;
            ObtenerMaxMin = obtenerMaxMin;
        }


        public void Alta( CabaniaDTO cabania)
        {
            Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Cabania");
            Cabania.largoMaximo = param.ValorMaximo;
            Cabania.largoMinimo = param.ValorMinimo;


            Cabania nueva = new() {
                Nombre = new NombreCabania(cabania.Nombre),
                Id = cabania.Id,
                Descripcion = cabania.Descripcion,
                TipoCabaniaId = cabania.TipoCabaniaId,
                Jacuzzi = cabania.Jacuzzi,
                Habilitada = cabania.Habilitada,
                CantidadPersonas = cabania.CantidadPersonas,
                Foto = cabania.Foto,
            };

            Repo.Add(nueva);
            cabania.Id = nueva.Id;
        }
    }
}
