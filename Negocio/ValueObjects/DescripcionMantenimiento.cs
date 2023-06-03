using Negocio.ExcepcionesPropias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ValueObjects
{
    public class DescripcionMantenimiento
    {
        public string Value { get; private set; }
        public DescripcionMantenimiento(string descripcion)
        {
            Value = descripcion;
            Validar();
        }

        private DescripcionMantenimiento() { }

        public void Validar()
        {

            if (Value.Length < 10 || Value.Length > 200 || Value == null)
            {
                throw new CaracteresDentroDeRango("La cantidad de caracteres debe de ser entre 10 y 200");
            }

        }
    }
}

