using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroApp.MVVM.Models
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }

        // Relación con Usuarios
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
