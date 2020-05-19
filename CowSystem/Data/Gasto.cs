using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class Gasto
    {
        [Key]
        public int IdGasto { get; set; }
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
