using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ExcepcionesPropias;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Entidades
{
    [Index(nameof(email), IsUnique = true)]
    public class Usuario : IValidable
    {
       
        public string email { get; set; }
        public string password { get; set; }
        public int Id { get; set; }

        public void Validar()
        {
            #region Validar Usuario

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                throw new CampoVacioException("Los campos no pueden estar vacios");
            }

            if(password.Length < 6 && !password.Any(char.IsUpper) == false && !password.Any(char.IsLower) == false && !password.Any(char.IsDigit) == false)
            {
                throw new ContraseñaException("La contraseña tiene que tener al menos 6 caracteres que incluyan letras mayúsculas " +
                    "\r\n y minúsculas (al menos una de cada una) y dígitos (0 al 9)");
            }


        #endregion
        }
    }
}
