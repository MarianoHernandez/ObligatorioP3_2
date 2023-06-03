using Negocio.Entidades;
using System.ComponentModel.DataAnnotations;

namespace PresentacionMVC.Models
{
    public class AltaCabaniaViewModel
    { 
        public Cabania CabaniaNueva { get; set; }
        public IEnumerable<TipoCabania> TiposCabania { get; set; }
        public int IdTipoCabania { get;set; }
        public IFormFile Foto { get; set; }
    }
}
