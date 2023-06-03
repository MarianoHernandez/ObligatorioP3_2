using Aplicacion.AplicacionParametros;
using Negocio.Entidades;
using Negocio.EntidadesAuxiliares;
using Negocio.InterfacesRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public class AltaTipoCabania : IAltaTipoCabania
    {
        public IRepositorioTipoCabania Repositorio { get; set; }


        public AltaTipoCabania(IRepositorioTipoCabania repo) { 
            Repositorio = repo;

        }

        public void Alta(TipoCabania tipoCabania)
        {
            Repositorio.Add(tipoCabania);
        }
    }
}
