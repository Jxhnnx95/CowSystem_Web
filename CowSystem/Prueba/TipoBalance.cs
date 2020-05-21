using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class TipoBalance
    {
        public TipoBalance()
        {
            HistorialFinanciero = new HashSet<HistorialFinanciero>();
        }

        public int IdTipoBalance { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        public ICollection<HistorialFinanciero> HistorialFinanciero { get; set; }
    }
}
