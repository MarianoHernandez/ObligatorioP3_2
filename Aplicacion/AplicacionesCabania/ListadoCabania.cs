using Negocio.InterfacesRepositorio;
using DTOs;
using Negocio.ValueObjects;

namespace Aplicacion.AplicacionesCabania
{
    public class ListadoCabania : IListadoCabania
    {
        public IRepositorioCabania RepositorioCabania { get; set; }
        public ListadoCabania(IRepositorioCabania repositorioCabania)
        {
            RepositorioCabania = repositorioCabania;
        }

        public IEnumerable<CabaniaDTO> ListadoAllCabania()
        {
            return RepositorioCabania.FindAll().Select(cab => new CabaniaDTO()
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
