using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public DateTime? UltimaActualizacion { get; set; }

        public virtual ICollection<HistorialFinanciero> HistorialFinanciero { get; set; }
        public virtual ICollection<Ganado> Ganado { get; set; }
        public virtual ICollection<Gasto> Gasto { get; set; }
    }
}
