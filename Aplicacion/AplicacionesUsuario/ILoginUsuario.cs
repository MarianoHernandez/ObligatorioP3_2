using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesUsuario
{
    public interface ILoginUsuario
    {
        public Usuario Login(Usuario usuario);
    }
}
