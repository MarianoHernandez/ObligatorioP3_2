
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

namespace Negocio.Entidades
{
    [Index(nameof(Nombre), IsUnique = true)]
    public class Cabania : IValidable
    {
        [DisplayName("Numero Habitacion")]
        public int Id { get; set; }

        public TipoCabania TipoCabania { get; set; }
        public int TipoCabaniaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Jacuzzi { get; set; }
        public bool Habilitada { get; set; }
        public int CantidadPersonas { get; set; }
        public string Foto { get; set; }
        private static int NumeroFoto { get; set; } = 1;

        public static int largoMaximo = 500;
        public static int largoMinimo = 10;

        public void Validar()
        {
            #region Validar Nombre
            if (string.IsNullOrEmpty(Nombre))
            {

                throw new NombreInvalidoException("El nombre no puede ser nulo o vacío");

            }
            if (Regex.IsMatch(Nombre, "^[a-zA-Z]+( [a-zA-Z]+)*$"))
            {
                throw new NombreInvalidoException("El nombre solo incluye caracteres alfabéticos y espacios embebidos, pero no al principio ni final");
            }

            #endregion

            #region Validar Descripcion

            if (Descripcion.Length < largoMinimo || Descripcion.Length > largoMaximo)
            {
                throw new DescripcionInvalidaException($"La descripcion no puede tener menos de {largoMinimo} caracteres ni mas de {largoMaximo}");
            }
            #endregion

        }
    }
}
