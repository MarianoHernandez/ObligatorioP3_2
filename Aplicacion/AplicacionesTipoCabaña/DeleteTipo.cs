using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class DeleteTipo : IDeleteTipo
    {
        public IRepositorioTipoCabania Repo { get; set; }
        public DeleteTipo(IRepositorioTipoCabania repositorioTipo) {
            Repo = repositorioTipo;
        }
        void IDeleteTipo.DeleteTipo(string nombre)
        {
            Repo.Remove(nombre);
        }
    }
}
