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
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario : IValidable
    {
       
        public string Email { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public int Id { get; set; }

        public void Validar()
        {
            #region Validar Usuario

            if (string.IsNullOrEmpty(Email))
            {
                throw new CampoVacioException("Los campos no pueden estar vacios");
            }

        #endregion
        }
    }
}
