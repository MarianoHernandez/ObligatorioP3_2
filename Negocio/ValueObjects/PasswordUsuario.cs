using Negocio.ExcepcionesPropias;
using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.ValueObjects
{
    public class PasswordUsuario :IValidable
    {

        public string Value { get; private set; }
        public PasswordUsuario(string password) 
        { 
            Value = password;
            Validar();
        }

        private PasswordUsuario() { }

        public void Validar()
        {

            if (string.IsNullOrEmpty(Value))
            {
                throw new CampoVacioException("La contraseña no puede estar vacia");
            }

            if (Value.Length < 6 && !Value.Any(char.IsUpper) == false && !Value.Any(char.IsLower) == false && !Value.Any(char.IsDigit) == false)
            {
                throw new ContraseñaException("La contraseña tiene que tener al menos 6 caracteres que incluyan letras mayúsculas " +
                    "\r\n y minúsculas (al menos una de cada una) y dígitos (0 al 9)");
            }

        }
    }
}
