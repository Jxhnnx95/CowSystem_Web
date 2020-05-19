using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class TipoGanado
    {
        [Key]
        public int IdTipoGanado { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
    }
}
