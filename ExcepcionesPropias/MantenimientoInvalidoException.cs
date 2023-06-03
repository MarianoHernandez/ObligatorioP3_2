using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class MantenimientoInvalidoException : Exception
    {
        public MantenimientoInvalidoException() { }

        public MantenimientoInvalidoException(string message) : base(message) { }

        public MantenimientoInvalidoException(string message, Exception inner) : base(message, inner) { }
    }
}
