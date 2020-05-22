using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class HistorialFinanciero
    {
        [Key]
        public int IdHistorial { get; set; }
        public int IdEmpresa { get; set; }
        public int IdGasto { get; set; }
        public int IdGanado { get; set; }
        public int IdTipoBalance { get; set; }
        public double Monto { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public virtual Ganado IdGanadoNavigation { get; set; }
        public virtual Gasto IdGastoNavigation { get; set; }
        public virtual TipoBalance IdTipoBalanceNavigation { get; set; }
    }
}
