using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Contacto { get; set; }
        public DateTime? UltimaActualizacion { get; set; }

        public ICollection<HistorialFinanciero> HistorialFinanciero { get; set; }
        public ICollection<Ganado> Ganado { get; set; }
        public ICollection<Gasto> Gasto { get; set; }
    }
}
