using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class EstadoGanado
    {
        public EstadoGanado()
        {
            Ganado = new HashSet<Ganado>();
        }

        public int IdEstadoGanado { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        public ICollection<Ganado> Ganado { get; set; }
    }
}
