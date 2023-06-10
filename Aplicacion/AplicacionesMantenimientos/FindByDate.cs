using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class FindByDate : IFindByDate
    {
        public IRepositorioMantenimiento Repo { get; set; }

        public FindByDate(IRepositorioMantenimiento repo)
        {
            Repo = repo;
        }
        public IEnumerable<MantenimientoDTO> FindByDateMantenimiento(DateTime d1, DateTime d2)
        {
            return Repo.FindMantenimiento(d1, d2).Select(mantenimiento => new MantenimientoDTO
            {
                fecha = mantenimiento.fecha,
                costo = mantenimiento.costo,
                trabajador = mantenimiento.trabajador,
                CabaniaId = mantenimiento.CabaniaId
            });
        }
    }
}
