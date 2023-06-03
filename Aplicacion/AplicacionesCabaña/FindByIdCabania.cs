using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabaña
{
    public class FindByIdCabania : IFindByIdCabania

    {
        public IRepositorioCabania RepositorioCabania { get; set; }

        public FindByIdCabania(IRepositorioCabania repo) {
            RepositorioCabania = repo;
        }


        public Cabania FindById(int id)
        {
            return RepositorioCabania.FindById(id);
        }
    }
}
