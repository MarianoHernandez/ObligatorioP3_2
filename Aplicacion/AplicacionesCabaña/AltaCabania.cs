using Aplicacion.AplicacionParametros;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public void Alta( Cabania cabania)
        {
            Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Cabania");
            Cabania.largoMaximo = param.ValorMaximo;
            Cabania.largoMinimo = param.ValorMinimo;
            Repo.Add(cabania);
        }
    }
}
