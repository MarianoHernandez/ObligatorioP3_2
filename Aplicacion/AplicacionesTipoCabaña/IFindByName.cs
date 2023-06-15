using DTOs;


namespace Aplicacion.AplicacionesTipoCabania
{
    public interface IFindByName
    {
        TipoCabaniaDTO FindOne(string nombre);
    }
}
