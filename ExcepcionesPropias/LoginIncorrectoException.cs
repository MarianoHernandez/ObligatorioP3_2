using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public  class LoginIncorrectoException : Exception
    {
        public LoginIncorrectoException() { }

        public LoginIncorrectoException(string message) : base(message) { }

        public LoginIncorrectoException(string message, Exception inner) : base(message, inner) { }
    }
}
