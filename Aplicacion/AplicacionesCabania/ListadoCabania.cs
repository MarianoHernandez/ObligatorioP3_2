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
            return RepositorioCabania.FindAll().Select(cabania => new CabaniaDTO()
            {
                Nombre = cabania.Nombre.Value,
                Id = cabania.Id,
                Descripcion = cabania.Descripcion.Value,
                TipoCabaniaId = cabania.TipoCabaniaId,
                Jacuzzi = cabania.Jacuzzi,
                Habilitada = cabania.Habilitada,
                CantidadPersonas = cabania.CantidadPersonas,
                Foto = cabania.Foto,
                TipoCabania = new TipoCabaniaDTO() { 
                    Id = cabania.TipoCabania.Id,
                    Costo = cabania.TipoCabania.Costo,
                    Descripcion = cabania.TipoCabania.Descripcion.Value,
                    Nombre =  cabania.TipoCabania.Nombre
                }
            }); ;
        }
    }
}
