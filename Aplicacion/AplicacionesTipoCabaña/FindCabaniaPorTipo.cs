using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class FindCabaniaPorTipo : IFindCabaniaPorTipo
    {
        public IRepositorioCabania Repositorio { get; set; }

        public FindCabaniaPorTipo(IRepositorioCabania repo) {
            Repositorio = repo;
        }

        public IEnumerable<Cabania> FindByTipoCabania(string nombre)
        {
            return Repositorio.FindCabañaTipo(nombre);
        }
    }
}
