using Negocio.InterfacesRepositorio;
using DTOs;
using Negocio.Entidades;
using Aplicacion.AplicacionParametros;
using Negocio.ValueObjects;
using Negocio.EntidadesAuxiliares;

namespace Aplicacion.AplicacionesTipoCabania
{
    public class UpdateTipo:IUpdateTipo
    {
        public IRepositorioTipoCabania Repositorio { get; set; }
        public IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }

        public UpdateTipo(IRepositorioTipoCabania repo, IObtenerMaxMinDescripcion obtenerMaxMin) {
            Repositorio = repo; 
            ObtenerMaxMin = obtenerMaxMin;
        }

        public void Update(TipoCabaniaDTO tipoCabania)
        {
            Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Tipo");
            DescripcionTipoCabania.CantMaxCarNombre = param.ValorMaximo;
            DescripcionTipoCabania.CantMinCarNombre = param.ValorMinimo;

            TipoCabania aModificar = new()
            {
                Id = tipoCabania.Id,
                Descripcion = new DescripcionTipoCabania(tipoCabania.Descripcion),
                Nombre = tipoCabania.Nombre,
                Costo = tipoCabania.Costo,
            };

            Repositorio.Update(aModificar);
        }
    }
}
