using DTOs;
using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabania
{
    public interface IUpdateTipo
    {
        void Update(TipoCabaniaDTO tipo);
    }
}
