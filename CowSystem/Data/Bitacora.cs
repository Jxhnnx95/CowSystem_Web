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
        public string Tabla { get; set; }
        public string Operacion { get; set; }
        public string Identificador { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
