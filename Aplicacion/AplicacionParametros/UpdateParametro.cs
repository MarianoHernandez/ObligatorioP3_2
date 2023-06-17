using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using Negocio.ValueObjects;
using PresentacionMVC.DTOs;


namespace Aplicacion.AplicacionParametros
{
    public class UpdateParametro :IUpdateParametro
    {
        public IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }
        public IRepositorioParametros Repo { get; set; }

        public UpdateParametro(IRepositorioParametros repo, IObtenerMaxMinDescripcion obtenerMaxMin)
        {
            ObtenerMaxMin = obtenerMaxMin;
            Repo = repo;
        }


        public void Update(DTOParametro param)
        {
            Parametro parametro = ObtenerMaxMin.ObtenerMaxMinDescripcion(param.Nombre);

            Parametro aModificar = new()
            {
                Id = parametro.Id,
                Nombre = param.Nombre,
                ValorMaximo = param.ValorMaximo,
                ValorMinimo = param.ValorMinimo,
            };

            Repo.Update(aModificar);
        }
    }
}
