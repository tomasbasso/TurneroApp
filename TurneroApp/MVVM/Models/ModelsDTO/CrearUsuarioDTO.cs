using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroApp.MVVM.Models.ModelsDTO
{
    public class CrearUsuarioDTO
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
    }
}
