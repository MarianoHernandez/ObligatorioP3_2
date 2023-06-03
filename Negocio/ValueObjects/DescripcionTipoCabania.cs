using Negocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ValueObjects
{
    public class DescripcionTipoCabania
    {
        public static int CantMinCarNombre { get; set; }
        public static int CantMaxCarNombre { get; set; }

        public string Value { get; private set; }

        public DescripcionTipoCabania(string Descripcion)
        {
            Value = Descripcion;
            Validar();
        }

        private DescripcionTipoCabania()
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
