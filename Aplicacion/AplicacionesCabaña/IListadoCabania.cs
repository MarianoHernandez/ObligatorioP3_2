using DTOs;

namespace Aplicacion.AplicacionesCabaña
{
    public interface IListadoCabania
    {
        public IEnumerable<CabaniaDTO> ListadoAllCabania();
    }
}
