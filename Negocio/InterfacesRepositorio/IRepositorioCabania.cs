using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Negocio.InterfacesRepositorio
{
    public interface IRepositorioCabania : IRepositorio<Cabania>
    {
        IEnumerable<Cabania> FindCabaña(string nombre, int tipo, int cantidadPers, bool habilitada  );
        IEnumerable<Cabania>  FindCabañaTipo(string nombre);
    }
}
