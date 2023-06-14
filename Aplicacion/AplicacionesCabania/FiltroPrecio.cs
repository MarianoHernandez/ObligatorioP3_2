using Aplicacion.AplicacionParametros;
using DTOs;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using Negocio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabania
{
    public class FiltroPrecio:IFiltroPrecio
    {
        public IRepositorioCabania Repo { get; set; }

        public FiltroPrecio(IRepositorioCabania repo)
        {

            Repo = repo;

        }


        public IEnumerable<CabaniaDTO> Filtro(decimal valor)
        {

            return Repo.FindPrecio(valor).Select(cabania => new CabaniaDTO()
            {
                Nombre = cabania.Nombre.Value,
                CantidadPersonas = cabania.CantidadPersonas,
            }); ;
        }
    }
}
