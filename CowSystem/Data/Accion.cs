using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CowSystem.Data
{
    public class Accion
    {
        [Key]
        public int IdAccion { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }
        public virtual ICollection<Bitacora> Bitacora { get; set; }
    }
}
