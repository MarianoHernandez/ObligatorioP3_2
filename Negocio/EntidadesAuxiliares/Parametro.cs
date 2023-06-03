
using System;
using Negocio.ExcepcionesPropias;
using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
using Negocio.ExcepcionesPropias.Cabanias;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace Negocio.EntidadesAuxiliares
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Parametro : IValidable
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ValorMaximo { get; set; }
        public int ValorMinimo { get; set; }

        public void Validar()
        {
            if (ValorMaximo < ValorMinimo)
            {
                throw new DescripcionInvalidaException("El valor Maximo de la descripcion tiene que ser mayor al Menor");
            }
        }
    }
}
