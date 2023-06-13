using Negocio.Entidades;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public interface IFindByIdTipo
    {
        public TipoCabania FindOneById(int id);
    }
}
