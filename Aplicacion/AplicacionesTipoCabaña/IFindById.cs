using Negocio.Entidades;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public interface IFindById
    {
        public TipoCabania FindOneById(int id);
    }
}
