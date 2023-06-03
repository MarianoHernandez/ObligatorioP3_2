using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class ListadoTipoCabania : IListadoTipoCabania
    {
        public IRepositorioTipoCabania Repo { get; set; }

        public ListadoTipoCabania(IRepositorioTipoCabania repo)
        {
            Repo = repo;
        }

        public IEnumerable<TipoCabania> ObtenerListado()
        {
           return Repo.FindAll();
        }
    }
}
