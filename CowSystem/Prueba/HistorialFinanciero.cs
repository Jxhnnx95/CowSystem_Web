using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class HistorialFinanciero
    {
        public int IdHistorial { get; set; }
        public int IdEmpresa { get; set; }
        public int? IdGasto { get; set; }
        public int IdGanado { get; set; }
        public int IdTipoBalance { get; set; }
        public double Monto { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        public Ganado IdGanadoNavigation { get; set; }
        public Gasto IdGastoNavigation { get; set; }
        public TipoBalance IdTipoBalanceNavigation { get; set; }
    }
}
