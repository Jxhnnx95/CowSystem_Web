using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class Ganado
    {
        public Ganado()
        {
            HistorialFinanciero = new HashSet<HistorialFinanciero>();
        }

        public int IdGanado { get; set; }
        public int IdEmpresa { get; set; }
        public string Codigo { get; set; }
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

        public EstadoGanado EstadoNavigation { get; set; }
        public TipoGanado TipoNavigation { get; set; }
        public ICollection<HistorialFinanciero> HistorialFinanciero { get; set; }
    }
}
