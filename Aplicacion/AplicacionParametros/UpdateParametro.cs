using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionParametros
{
    public class UpdateParametro :IUpdateParametro
    {

        public IRepositorioParametros Repo { get; set; }
        public UpdateParametro(IRepositorioParametros repo)
        {

            Repo = repo;
        }


        public void Update(Parametro param)
        {
            Repo.Update(param);
        }
    }
}
