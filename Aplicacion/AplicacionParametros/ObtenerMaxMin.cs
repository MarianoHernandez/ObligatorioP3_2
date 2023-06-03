using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;

namespace Aplicacion.AplicacionParametros
{
    public class ObtenerMaxMin : IObtenerMaxMinDescripcion
    {
        public IRepositorioParametros Repo { get; set; }

        public ObtenerMaxMin(IRepositorioParametros repo)
        {

            Repo = repo;
        }


        public Parametro ObtenerMaxMinDescripcion(string nombre)
        {
            return Repo.ObtenerParametros(nombre);
                
        }
    }
}

