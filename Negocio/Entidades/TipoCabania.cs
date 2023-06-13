using Microsoft.EntityFrameworkCore;
using Negocio.ExcepcionesPropias.Cabanias;
using Negocio.InterfacesDominio;
using Negocio.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;


namespace Negocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class TipoCabania:IValidable
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        [Display(Name = "Descripcion de tipo")]
        public DescripcionTipoCabania Descripcion { get; set;}
        
        public decimal Costo { get; set; }

        public void Validar()
        {
            if (! Regex.IsMatch(Nombre, "^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                throw new NombreInvalidoException("El nombre solo incluye caracteres alfabéticos y espacios embebidos, pero no al principio ni final)");
            }

            if (Costo<0) {
                throw new Exception("El costo debe ser positivo");
            }
            
        }
    }
}
