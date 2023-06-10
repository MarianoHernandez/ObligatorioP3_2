using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Aplicacion.AplicacionesMantenimientos
{
    public interface IFindByDate
    {
           IEnumerable<MantenimientoDTO> FindByDateMantenimiento(DateTime d1, DateTime d2);
       
    }
}
