using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesUsuario
{
    public class LoginUsuario : ILoginUsuario
    {
        public IRepositorioUsuario Repo { get; set; }
        public LoginUsuario(IRepositorioUsuario repo)
        {
            Repo = repo;
        }

        public Usuario Login(Usuario login)
        {
            return Repo.Login(login);
        }
    }
}
