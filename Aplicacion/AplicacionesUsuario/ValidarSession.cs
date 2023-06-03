using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesUsuario
{
    public class ValidarSession:IValidarSession
    {
        public IRepositorioUsuario Repo { get; set; }
        public ValidarSession(IRepositorioUsuario repo)
        {
            Repo = repo;
        }
        public void Validar(string email) {
            Repo.ValidarSession(email);
        }
    }
}
