using DTOs;
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

        public UsuarioDTO Login(string email, string pass)
        {
            UsuarioDTO dto = null;
            Usuario usu = Repo.Login(email, pass);

            if (usu != null)
            {
                dto = new UsuarioDTO()
                {
                    Id = usu.Id,
                    Email = usu.Email,
                    Password = usu.Password,
                    Rol = usu.Rol
                };
            }
            return dto;
        }
    }
}
