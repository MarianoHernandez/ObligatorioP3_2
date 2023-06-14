using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Negocio.ValueObjects
{
    public class NombreCabania : IValidable
    {

        public string Value { get; private set; }

        public NombreCabania(string nom)
        {
            Value = nom;
            Validar();
        }

        private NombreCabania()
        {
        }

        public void Validar()
        {
            #region Validar Nombre
            if (string.IsNullOrEmpty(Value))
            {

                throw new NombreInvalidoException("El nombre no puede ser nulo o vacío");

            }
            if (!Regex.IsMatch(Value, "^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                throw new NombreInvalidoException("El nombre solo incluye caracteres alfabéticos y espacios embebidos, pero no al principio ni final");
            }

            #endregion
        }
    }
}
