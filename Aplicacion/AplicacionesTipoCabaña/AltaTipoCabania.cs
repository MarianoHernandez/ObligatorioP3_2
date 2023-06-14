using Aplicacion.AplicacionParametros;
using DTOs;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using Negocio.ValueObjects;

namespace Aplicacion.AplicacionesTipoCabania
{
    public class AltaTipoCabania : IAltaTipoCabania
    {
        public IRepositorioTipoCabania Repositorio { get; set; }
        public IObtenerMaxMinDescripcion ObtenerMaxMin { get; set; }

        public AltaTipoCabania(IRepositorioTipoCabania repo, IObtenerMaxMinDescripcion obtenerMaxMin) { 
            Repositorio = repo;
            ObtenerMaxMin = obtenerMaxMin;
        }

        public void Alta(TipoCabaniaDTO tipoCabania)
        {
            Parametro param = ObtenerMaxMin.ObtenerMaxMinDescripcion("Tipo");
            DescripcionTipoCabania.CantMaxCarNombre = param.ValorMaximo;
            DescripcionTipoCabania.CantMinCarNombre = param.ValorMinimo;


            TipoCabania nuevo = new()
            {
                Id = tipoCabania.Id,
                Descripcion = new DescripcionTipoCabania(tipoCabania.Descripcion),
                Nombre = tipoCabania.Nombre,
                Costo = tipoCabania.Costo,
            };            

            Repositorio.Add(nuevo);
            tipoCabania.Id = nuevo.Id;
        }
    }
}
