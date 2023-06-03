using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class FindById : IFindById
    {
        public IRepositorioTipoCabania Repo;

        public FindById(IRepositorioTipoCabania repo)
        {
            Repo = repo;
        }

        public TipoCabania FindOneById(int id)
        {
           return Repo.FindById(id);
        }
    }
}
