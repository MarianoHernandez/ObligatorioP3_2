using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class CampoVacioException : Exception
    {
        public CampoVacioException() { }

        public CampoVacioException(string message) : base(message) { }

        public CampoVacioException(string message, Exception inner) : base(message, inner) { }

    }
}
