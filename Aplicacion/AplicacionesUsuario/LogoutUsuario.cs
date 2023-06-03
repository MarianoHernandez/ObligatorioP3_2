using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesUsuario
{
    public class LogoutUsuario : ILogoutUsuario
    {
        public IRepositorioUsuario Repo { get; set; }
        public LogoutUsuario (IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public void Logout()
        {
            Repo.Logout();
        }
    }
}
