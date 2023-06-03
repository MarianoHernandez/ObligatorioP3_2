using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MantenimientoDTO
    {
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        public decimal costo { get; set; }
        [Required]
        public string trabajador { get; set; }
        public int CabaniaId { get; set; }
        public int Id { get; set; }
    }
}
