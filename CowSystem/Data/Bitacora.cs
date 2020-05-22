using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class Bitacora
    {
        [Key]
        public int IdRegistro { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdGanado { get; set; }
        public int? IdAccion { get; set; }
        public int? IdHistorial { get; set; }
        public string Url { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public virtual Empresa EmpresaNavigation { get; set; }
        public virtual Ganado GanadoNavigation { get; set; }
        public virtual Accion AccionNavigation { get; set; }
        public virtual HistorialFinanciero HistorialNavigation { get; set; }
    }
}
