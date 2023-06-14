using Negocio.Entidades;
using Negocio.InterfacesRepositorio;

namespace Aplicacion.AplicacionesTipoCabania
{
    public class FindCabaniaPorTipo : IFindCabaniaPorTipo
    {
        public IRepositorioCabania Repositorio { get; set; }

        public FindCabaniaPorTipo(IRepositorioCabania repo) {
            Repositorio = repo;
        }

        public IEnumerable<Cabania> FindByTipoCabania(string nombre)
        {
            return Repositorio.FindCabañaTipo(nombre);
        }
    }
}
