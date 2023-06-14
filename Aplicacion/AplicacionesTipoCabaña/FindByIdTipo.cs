using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabania
{
    public class FindByIdTipo : IFindByIdTipo
    {
        public IRepositorioTipoCabania Repo;

        public FindByIdTipo(IRepositorioTipoCabania repo)
        {
            Repo = repo;
        }

        public TipoCabania FindOneById(int id)
        {
           return Repo.FindById(id);
        }
    }
}
