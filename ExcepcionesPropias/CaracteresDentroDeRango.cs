using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ExcepcionesPropias
{
    public class CaracteresDentroDeRango : Exception
    {
        public CaracteresDentroDeRango() { }

        public CaracteresDentroDeRango(string message) : base(message) { }

        public CaracteresDentroDeRango(string message, Exception inner) : base(message, inner) { }
    }
}
