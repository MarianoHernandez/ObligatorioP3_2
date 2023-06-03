using Negocio.Entidades;
using Negocio.ExcepcionesPropias;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesMantenimientos
{
    public class AltaMantenimiento : IAltaMantenimiento
    {
        public IRepositorioMantenimiento Repo { get; set; }

        public AltaMantenimiento(IRepositorioMantenimiento repo)
        {

            Repo = repo;
        }


        public void Alta(Mantenimiento mantenimiento)
        {
           
            Repo.Add(mantenimiento);


        }
    }
}
