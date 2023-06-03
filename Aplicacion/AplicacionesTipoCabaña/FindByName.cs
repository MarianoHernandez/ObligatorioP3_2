using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class FindByName:IFindByName
    {
        public IRepositorioTipoCabania Repo { get; set; }

        public FindByName(IRepositorioTipoCabania repo)
        {
            Repo = repo;
        }

        public TipoCabania FindOne(string nombre)
        {
            return Repo.FindByName(nombre);
        }
    }
}
