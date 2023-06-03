using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class FindByDate : IFindByDate
    {
        public IRepositorioMantenimiento Repo { get; set; }

        public FindByDate(IRepositorioMantenimiento repo)
        {
            Repo = repo;
        }
        public IEnumerable<Mantenimiento> FindByDateMantenimiento(DateTime d1, DateTime d2)
        {
            return Repo.FindMantenimiento(d1, d2);
        }
    }
}
