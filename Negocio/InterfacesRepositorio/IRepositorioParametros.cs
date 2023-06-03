using Negocio.EntidadesAuxiliares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioParametros :IRepositorio<Parametro>
    {
        Parametro ObtenerParametros(string nombre);

    }
}
