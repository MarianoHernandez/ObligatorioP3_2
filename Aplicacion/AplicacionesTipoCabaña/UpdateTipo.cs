using Negocio.Entidades;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class UpdateTipo:IUpdateTipo
    {
        public IRepositorioTipoCabania Repositorio { get; set; }
        public UpdateTipo(IRepositorioTipoCabania repo) {
            Repositorio = repo; 
        }

        public void Update(TipoCabania tipo)
        {
            Repositorio.Update(tipo);
        }
    }
}
