using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class FindByCabania:IFindByCabania
    {
        IRepositorioMantenimiento Repo { get; set; }
        public FindByCabania(IRepositorioMantenimiento repo) {
            Repo = repo;
        }
        public IEnumerable<Mantenimiento> FindMantenimientoByCabania(int id) {
           return Repo.FindByCabania(id);
        }

    }
}
