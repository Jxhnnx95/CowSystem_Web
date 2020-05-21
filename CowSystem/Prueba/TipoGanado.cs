using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class TipoGanado
    {
        public TipoGanado()
        {
            Ganado = new HashSet<Ganado>();
        }

        public int IdTipoGanado { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        public ICollection<Ganado> Ganado { get; set; }
    }
}
