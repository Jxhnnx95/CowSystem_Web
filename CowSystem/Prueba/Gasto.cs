using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class Gasto
    {
        public Gasto()
        {
            HistorialFinanciero = new HashSet<HistorialFinanciero>();
        }

        public int IdGasto { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Fecha { get; set; }
        public string Factura { get; set; }
        public string Proveedor { get; set; }
        public double Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime UltimaActualizacion { get; set; }

        public ICollection<HistorialFinanciero> HistorialFinanciero { get; set; }
    }
}
