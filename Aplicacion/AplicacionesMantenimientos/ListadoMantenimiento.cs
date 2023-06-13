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

        public IEnumerable<Mantenimiento> ObtenerListado()
        {
            return Repo.FindAll();
        }

        public IEnumerable<Mantenimiento> ListadoAllMantenimientos()
        {
            return Repo.FindAll();
        }

        IEnumerable<MantenimientoDTO> IListadoMantenimiento.ListadoAllMantenimientos()
        {
            throw new NotImplementedException();
        }
    }
}
