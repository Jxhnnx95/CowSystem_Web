using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class TipoBalance
    {
        [Key]
        public int IdTipoBalance { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
