using Negocio.ExcepcionesPropias;
using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ValueObjects
{
    public class DescripcionCabania : IValidable
    {
        public static int CantMinCarNombre { get; set; }
        public static int CantMaxCarNombre { get; set; }

        public string Value { get; private set; }

        public DescripcionCabania(string Descripcion)
        {
            Value = Descripcion;
            Validar();
        }

        private DescripcionCabania()
        {
        }

        public void Validar()
        {
            if (Value.Length > CantMaxCarNombre || Value.Length < CantMinCarNombre)
            {
                throw new DescripcionInvalidaException($"La descripcion no puede tener menos de {CantMinCarNombre} caracteres ni mas de {CantMaxCarNombre}");
            }
        }
    }
}
