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
    public class FindByName:IFindByName
    {
        public IRepositorioTipoCabania Repo { get; set; }

        public FindByName(IRepositorioTipoCabania repo)
        {
            Repo = repo;
        }

        public TipoCabaniaDTO FindOne(string nombre)
        {
            TipoCabania tipo = Repo.FindByName(nombre);

            TipoCabaniaDTO nuevo = new() { 
                Nombre = tipo.Nombre,
                Costo = tipo.Costo,
                Descripcion = tipo.Descripcion.Value,
                Id = tipo.Id
            };
            return nuevo;
        }
    }
}
