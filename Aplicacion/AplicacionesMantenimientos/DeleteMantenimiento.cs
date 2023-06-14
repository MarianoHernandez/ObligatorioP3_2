using Aplicacion.AplicacionesTipoCabania;
using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class DeleteMantenimiento : IDeleteMantenimiento
    {
        public IRepositorioMantenimiento Repo { get; set; }
        public DeleteMantenimiento(IRepositorioMantenimiento mantenimiento)
        {
            Repo = mantenimiento;
        }
        void IDeleteMantenimiento.DeleteMantenimiento(Mantenimiento mantenimiento )
        {
            Repo.Remove(mantenimiento);
        }
    }
}
