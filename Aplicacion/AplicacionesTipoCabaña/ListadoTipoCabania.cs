using DTOs;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabania
{
    public class ListadoTipoCabania : IListadoTipoCabania
    {
        public IRepositorioTipoCabania Repo { get; set; }

        public ListadoTipoCabania(IRepositorioTipoCabania repo)
        {
            Repo = repo;
        }

        public IEnumerable<TipoCabaniaDTO> ObtenerListado()
        {
           return Repo.FindAll().Select(tipo => new TipoCabaniaDTO()
           {
               Id = tipo.Id,
               Nombre = tipo.Nombre,
               Descripcion = tipo.Descripcion.Value,
               Costo = tipo.Costo
           });
        }
    }
}
