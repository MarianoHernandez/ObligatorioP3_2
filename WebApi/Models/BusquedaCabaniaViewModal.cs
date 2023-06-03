using Negocio.Entidades;

namespace PresentacionMVC.Models
{
    public class BusquedaCabaniaViewModal
    {
        public string Nombre;
        public int TipoID;
        public int CantidadPersonas;
        public bool Habilitada;
        public IEnumerable<TipoCabania> TiposCabania { get; set; }
        public IEnumerable<Cabania> Cabanias { get; set; }

    }
}
