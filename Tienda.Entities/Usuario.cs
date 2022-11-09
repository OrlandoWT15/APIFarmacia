using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string usuario { get; set; }
        public string Contrasenia { get; set; }
        public Boolean Estado { get; set; }
    }
}
