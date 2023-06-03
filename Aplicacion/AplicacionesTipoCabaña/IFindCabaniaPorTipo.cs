using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesTipoCabaña
{
    public interface IFindCabaniaPorTipo
    {
        public IEnumerable<Cabania> FindByTipoCabania(string nombre);
    }
}
