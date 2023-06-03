using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabaña
{
    public class BusquedaConFiltros :IBusquedaConFiltros
    {
        public IRepositorioCabania Repo;
        public BusquedaConFiltros(IRepositorioCabania repo)
        {
            Repo = repo;
        }

        public IEnumerable<Cabania> GetCabanias(string nombre, int tipo, int cantidadPers, bool habilitada)
        {
            return Repo.FindCabaña(nombre, tipo, cantidadPers, habilitada);
        }
    }
}
