using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class ContraseñaException : Exception
    {
        public ContraseñaException() { }

        public ContraseñaException(string message) : base(message) { }

        public ContraseñaException(string message, Exception inner) : base(message, inner) { }
    }
}

