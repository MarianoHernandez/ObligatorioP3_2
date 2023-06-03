using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class ExisteOtroElementoRelacionado : Exception
    {

        public ExisteOtroElementoRelacionado() { }

        public ExisteOtroElementoRelacionado(string message) : base(message) { }

        public ExisteOtroElementoRelacionado(string message, Exception inner) : base(message, inner) { }

    }
}
