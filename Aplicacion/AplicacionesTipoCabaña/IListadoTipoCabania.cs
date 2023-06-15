using DTOs;


namespace Aplicacion.AplicacionesTipoCabania
{
    public interface IListadoTipoCabania
    {
        IEnumerable<TipoCabaniaDTO> ObtenerListado();
    }
}
