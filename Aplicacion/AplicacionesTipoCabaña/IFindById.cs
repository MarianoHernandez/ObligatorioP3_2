using Negocio.Entidades;

namespace Aplicacion.AplicacionesTipoCabania
{
    public interface IFindByIdTipo
    {
        public TipoCabania FindOneById(int id);
    }
}
