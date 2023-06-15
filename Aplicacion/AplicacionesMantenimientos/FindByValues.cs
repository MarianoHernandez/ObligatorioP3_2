using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Negocio.InterfacesRepositorio;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class FindByValues : IFindByValues
    {
        IRepositorioMantenimiento Repo { get; set; }
        public FindByValues(IRepositorioMantenimiento repo)
        {
            Repo = repo;
        }
        public IEnumerable<MantenimientoDTO> MantenimientosPorValores(int c1, int c2, string nombreEmpleado)
        {

            return Repo.MantenimientosPorValores(c1, c2, nombreEmpleado).Select(mantenimiento => new MantenimientoDTO
            {
                fecha = mantenimiento.fecha,
                costo = mantenimiento.costo,
                descripcion = mantenimiento.descripcion.Value,
                trabajador = mantenimiento.trabajador,
                CabaniaId = mantenimiento.CabaniaId,
                Id = mantenimiento.Id
            });
        }

    }
}
