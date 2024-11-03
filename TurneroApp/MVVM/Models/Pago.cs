using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroApp.MVVM.Models
{
    public class Pago
    {
        [Key]
        public int IdPago { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }

        // Relación con Usuario
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        // Relación con Turno
        public int IdTurno { get; set; }
        public Turno Turno { get; set; }
    }
}
