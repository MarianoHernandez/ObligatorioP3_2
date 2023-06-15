using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public interface IFindByValues
    {
        public IEnumerable<MantenimientoDTO> MantenimientosPorValores(int c1, int c2, string nombreEmpleado);
    }
}
