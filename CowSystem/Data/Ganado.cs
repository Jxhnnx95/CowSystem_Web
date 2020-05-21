using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class Ganado
    {
        [Key]
        public int IdGanado { get; set; }
        public string Codigo { get; set; }
        [ForeignKey("TipoNavigation")]
        public int? Tipo { get; set; }
        public int? Estado { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public double? Peso { get; set; }
        public double? Valor { get; set; }
        public DateTime? ValorPeso { get; set; }
        public int? IdMadre { get; set; }
        public int? IdPadre { get; set; }
        public int? Partos { get; set; }
        public DateTime? UltimaActualizacion { get; set; }

        public virtual EstadoGanado EstadoNavigation { get; set; }
        
        public virtual TipoGanado TipoNavigation { get; set; }
        public virtual ICollection<HistorialFinanciero> HistorialFinanciero { get; set; }
    }
}
