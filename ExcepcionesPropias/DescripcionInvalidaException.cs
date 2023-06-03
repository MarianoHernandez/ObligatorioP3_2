using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class DescripcionInvalidaException : Exception
    {
        public DescripcionInvalidaException() { }
        public DescripcionInvalidaException(string message) : base(message) { }
        public DescripcionInvalidaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
