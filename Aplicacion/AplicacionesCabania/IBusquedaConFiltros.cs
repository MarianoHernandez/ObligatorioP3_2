using DTOs;


namespace Aplicacion.AplicacionesCabania
{
    public interface IBusquedaConFiltros
    {
        IEnumerable<CabaniaDTO> GetCabanias(string? nombre, int? tipo, int? cantidadPers, bool? habilitada);
    }
}
