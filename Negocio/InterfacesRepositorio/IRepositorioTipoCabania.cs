using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioTipoCabania:IRepositorio<TipoCabania>
    {
        public TipoCabania FindByName(string nombre);
        public void Remove(string nombre);
    }
}
