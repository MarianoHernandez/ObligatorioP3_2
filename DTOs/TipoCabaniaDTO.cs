using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TipoCabaniaDTO
    {
        public TipoCabaniaDTO(int id, string nombre, string descripcion, decimal costo)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Costo = costo;
        }

        public int Id { get; set; }

        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        public decimal Costo { get; set; }
    }
}
