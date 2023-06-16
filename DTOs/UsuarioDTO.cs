using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class UsuarioDTO
    {
        public string Email { get; set; }
        public string Rol { get; set; }

        public string Password { get; set; }
        public int Id { get; set; }
    }
}
