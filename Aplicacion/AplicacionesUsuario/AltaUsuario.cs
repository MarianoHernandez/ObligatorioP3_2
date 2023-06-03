using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesUsuario
{
    public class AltaUsuario : IAltaUsuario
    {
        public IRepositorioUsuario Repo { get; set; }

        public AltaUsuario (IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Alta(Usuario usuario)
        {
            Repo.Add(usuario);
        }
    }
}
