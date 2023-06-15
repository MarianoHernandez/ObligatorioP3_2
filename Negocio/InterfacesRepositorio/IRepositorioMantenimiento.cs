using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioMantenimiento : IRepositorio<Mantenimiento>
    {
        public IEnumerable<Mantenimiento> FindMantenimiento(DateTime d1, DateTime d2);
        public void Remove(Mantenimiento mantenimiento);
        public IEnumerable<Mantenimiento> FindByCabania(int id);

        public IEnumerable<Mantenimiento> MantenimientosPorValores(int c1, int c2, string nombreEmpleado);
    }
}
