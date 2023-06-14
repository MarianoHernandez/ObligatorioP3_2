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
            return Repo.FindCabaña(nombre, tipo, cantidadPers, habilitada).Select(cab => new CabaniaDTO()
            {
                    Id = cab.Id,
                    Nombre = cab.Nombre.Value,
                    TipoCabaniaId = cab.TipoCabaniaId,
                    Descripcion = cab.Descripcion.Value,
                    Jacuzzi = cab.Jacuzzi,
                    Habilitada = cab.Habilitada,
                    CantidadPersonas = cab.CantidadPersonas,
                    Foto = cab.Foto,
                    TipoCabaniaDTO = new TipoCabaniaDTO()
                    {
                        Id = cab.TipoCabania.Id,
                        Nombre = cab.TipoCabania.Nombre,
                        Descripcion = cab.TipoCabania.Descripcion.Value,
                        Costo = cab.TipoCabania.Costo
                    }
              
            });
        }
    }
}
