using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Aplicacion.AplicacionesMantenimientos
{
    public interface IListadoMantenimiento
    {
        public IEnumerable<MantenimientoDTO> ListadoAllMantenimientos();
    }
}
