using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public interface IFindByDate
    {
           IEnumerable<Mantenimiento> FindByDateMantenimiento(DateTime d1, DateTime d2);
       
    }
}
