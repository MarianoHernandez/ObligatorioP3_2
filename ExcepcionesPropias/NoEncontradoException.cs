using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class NoEncontradoException:Exception
    {
        public NoEncontradoException() { }

        public NoEncontradoException(string message) : base(message) { }

        public NoEncontradoException(string message, Exception inner) : base(message, inner) { }
    }
}
