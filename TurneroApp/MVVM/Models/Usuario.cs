using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroApp.MVVM.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }

        // Relación con Rol
        public int IdRol { get; set; }
        public Rol Rol { get; set; }

        // Relaciones con Turnos
        public ICollection<Turno> TurnosCliente { get; set; }  // Turnos como cliente
        public ICollection<Turno> TurnosPeluquero { get; set; } // Turnos como peluquero

        // Relaciones con Horarios Disponibles
        public ICollection<HorarioDisponible> HorariosDisponibles { get; set; }
    }
}
