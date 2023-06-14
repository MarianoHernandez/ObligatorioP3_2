using DTOs;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabania
{
    public class BusquedaConFiltros :IBusquedaConFiltros
    {
        public IRepositorioCabania Repo;
        public BusquedaConFiltros(IRepositorioCabania repo)
        {
            Repo = repo;
        }

        public IEnumerable<CabaniaDTO> GetCabanias(string? nombre, int? tipo, int? cantidadPers, bool? habilitada)
        {
            return Repo.FindCabaña(nombre, tipo, cantidadPers, habilitada).Select(cabania => new CabaniaDTO()
            {
                Nombre = cabania.Nombre.Value,
                Id = cabania.Id,
                Descripcion = cabania.Descripcion.Value,
                TipoCabaniaId = cabania.TipoCabaniaId,
                Jacuzzi = cabania.Jacuzzi,
                Habilitada = cabania.Habilitada,
                CantidadPersonas = cabania.CantidadPersonas,
                Foto = cabania.Foto,
            });
        }
    }
}
