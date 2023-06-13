﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CabaniaDTO
    {


        public int Id { get; set; }

        public int TipoCabaniaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Jacuzzi { get; set; }

        public bool Habilitada { get; set; }

        public int CantidadPersonas { get; set; }

        public string Foto { get; set; }

        public TipoCabaniaDTO TipoCabania { get; set; }

    }
}
