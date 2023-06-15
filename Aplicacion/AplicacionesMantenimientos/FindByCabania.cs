using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Negocio.ValueObjects;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class FindByCabania:IFindByCabania
    {
        IRepositorioMantenimiento Repo { get; set; }
        public FindByCabania(IRepositorioMantenimiento repo) {
            Repo = repo;
        }
        public IEnumerable<MantenimientoDTO> FindMantenimientoByCabania(int id) {
            
           return Repo.FindByCabania(id).Select(mantenimiento=> new MantenimientoDTO
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
