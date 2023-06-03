using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Datos.Entity;
using Negocio.ExcepcionesPropias;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace Datos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioUsuario(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Usuario obj)
        {
            obj.Validar();
            Contexto.Usuario.Add(obj);
            Contexto.SaveChanges();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }

        public Usuario Login(Usuario usuario)
        {
            
           Usuario encontrado = Contexto.Usuario
                            .Where(usu => usu.email == usuario.email && usu.password == usuario.password)
                            .SingleOrDefault();
            if(encontrado == null)
            {
                throw new LoginIncorrectoException("Email o contraseña incorrecta");
            }
            return encontrado;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void ValidarSession(string email) {

            if (email==null) {
                throw new LoginIncorrectoException("Se necesita iniciar sesion");
            }
        }
    }
}
