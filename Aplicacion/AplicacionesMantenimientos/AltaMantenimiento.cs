using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using DTOs;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.ValueObjects;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class AltaMantenimiento : IAltaMantenimiento
    {
        public IRepositorioMantenimiento Repo { get; set; }

        public AltaMantenimiento(IRepositorioMantenimiento repo)
        {

            Repo = repo;
        }


        public void Alta(MantenimientoDTO mantenimiento)
        {

            Mantenimiento nuevo = new Mantenimiento()
            {
                fecha = mantenimiento.fecha,
                descripcion = new DescripcionMantenimiento(mantenimiento.descripcion),
                costo = mantenimiento.costo,
                trabajador = mantenimiento.trabajador,
                CabaniaId = mantenimiento.CabaniaId

            };
            Repo.Add(nuevo);
            mantenimiento.Id = nuevo.Id;


        }
    }
}
