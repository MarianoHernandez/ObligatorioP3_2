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

namespace Aplicacion.AplicacionesCabania
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


        public void Alta( CabaniaDTO cabania, TipoCabania tipo)
        {
            Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Cabania");
            DescripcionCabania.CantMaxCarNombre = param.ValorMaximo;
            DescripcionCabania.CantMinCarNombre = param.ValorMinimo;


            Cabania nueva = new() {
                Nombre = new NombreCabania(cabania.Nombre),
                Id = cabania.Id,
                Descripcion = new DescripcionCabania(cabania.Descripcion),
                TipoCabaniaId = cabania.TipoCabaniaId,
                Jacuzzi = cabania.Jacuzzi,
                Habilitada = cabania.Habilitada,
                CantidadPersonas = cabania.CantidadPersonas,
                Foto = cabania.Foto,
                TipoCabania = tipo,
            };

            Repo.Add(nueva);
            cabania.Id = nueva.Id;
        }
    }
}
