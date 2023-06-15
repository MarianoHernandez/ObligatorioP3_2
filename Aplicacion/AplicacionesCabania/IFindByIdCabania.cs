using DTOs;
using Negocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AplicacionesCabania
{
    public interface IFindByIdCabania
    {
        public CabaniaDTO FindById(int id);
    }
}
