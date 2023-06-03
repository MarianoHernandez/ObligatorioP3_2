using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CabaniaDTO
    {
        public CabaniaDTO(int id, TipoCabaniaDTO tipoCabania, int tipoCabaniaId, string nombre, string descripcion, bool jacuzzi, bool habilitada, int cantidadPersonas, string foto)
        {
            Id = id;
            TipoCabania = tipoCabania;
            TipoCabaniaId = tipoCabaniaId;
            Nombre = nombre;
            Descripcion = descripcion;
            Jacuzzi = jacuzzi;
            Habilitada = habilitada;
            CantidadPersonas = cantidadPersonas;
            Foto = foto;
        }

        public int Id { get; set; }

        public TipoCabaniaDTO TipoCabania { get; set; }

        public int TipoCabaniaId { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public bool Jacuzzi { get; set; }

        public bool Habilitada { get; set; }

        public int CantidadPersonas { get; set; }

        public string Foto { get; set; }

    }
}
