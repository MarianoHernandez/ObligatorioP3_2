using DTOs;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class ListadoMantenimiento : IListadoMantenimiento
    {
        public IRepositorioMantenimiento Repo { get; set; }

        public ListadoMantenimiento(IRepositorioMantenimiento repo)
        {
            Repo = repo;
        }

        public IEnumerable<MantenimientoDTO> ListadoAllMantenimientos()
        {
            return Repo.FindAll().Select(mantenimiento => new MantenimientoDTO
            {
                fecha = mantenimiento.fecha,
                costo = mantenimiento.costo,
                descripcion = mantenimiento.descripcion.Value,
                trabajador = mantenimiento.trabajador,
                CabaniaId = mantenimiento.CabaniaId
            }); ; 
        }

        //IEnumerable<MantenimientoDTO> IListadoMantenimiento.ListadoAllMantenimientos()
        //{
        //    return Repo.FindAll().Select(mantenimiento => new MantenimientoDTO
        //    {
        //        fecha = mantenimiento.fecha,
        //        costo = mantenimiento.costo,
        //        trabajador = mantenimiento.trabajador,
        //        CabaniaId = mantenimiento.CabaniaId
        //    });
        //}
    }
}
