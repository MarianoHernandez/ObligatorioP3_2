﻿using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabania
{
    public interface IFindByName
    {
        TipoCabania FindOne(string nombre);
    }
}
