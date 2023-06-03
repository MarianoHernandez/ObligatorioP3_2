using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Aplicacion.AplicacionesCabaña
{
    public class ListadoCabania : IListadoCabania
    {
        public IRepositorioCabania RepositorioCabania { get; set; }
        public ListadoCabania(IRepositorioCabania repositorioCabania)
        {
            RepositorioCabania = repositorioCabania;
        }

        public IEnumerable<Cabania> ListadoAllCabania()
        {
            return RepositorioCabania.FindAll();
        }
    }
}
