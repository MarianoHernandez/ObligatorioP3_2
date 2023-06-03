
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
using Negocio.ValueObjects;


namespace Negocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Cabania : IValidable
    {
        [DisplayName("Numero Habitacion")]
        public int Id { get; set; }

        public TipoCabania TipoCabania { get; set; }
        
        public int TipoCabaniaId { get; set; }
        
        [Display(Name = "Nombre del tema")]
        public NombreCabania Nombre { get; set; }

        public string Descripcion { get; set; }
        
        public bool Jacuzzi { get; set; }
        
        public bool Habilitada { get; set; }
        
        public int CantidadPersonas { get; set; }
        
        public string Foto { get; set; }
        

        public static int largoMaximo = 500;
        public static int largoMinimo = 10;


        public void Validar()
        {
            #region Validar Descripcion

            if (Descripcion.Length < largoMinimo || Descripcion.Length > largoMaximo)
            {
                throw new DescripcionInvalidaException($"La descripcion no puede tener menos de {largoMinimo} caracteres ni mas de {largoMaximo}");
            }
            #endregion

        }
    }
}
