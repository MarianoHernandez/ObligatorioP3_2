﻿using Negocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ExcepcionesPropias;
using System.ComponentModel.DataAnnotations;
using Negocio.ValueObjects;

namespace Negocio.Entidades
{
    public class Mantenimiento : IValidable
    {
        public DateTime fecha { get; set; }
        public DescripcionMantenimiento descripcion { get; set; }
        public decimal costo { get; set; }
        [Required]
        public string trabajador { get; set; }
        public Cabania cabania { get; set; }
        public int CabaniaId { get; set; }
        public int Id { get; set; }


        public void Validar()
        {
            #region Validar
            if (fecha == null)
            {
                throw new CampoVacioException("El campo no puede estar vacio");
            }
            if (costo <= 0)
            {
                throw new CampoVacioException("El campo no puede estar vacio o mayor a 0");
            }
            if (cabania == null)
            {
                throw new CampoVacioException("El campo no puede estar vacio");
            }

            #endregion
        }
    }
}
