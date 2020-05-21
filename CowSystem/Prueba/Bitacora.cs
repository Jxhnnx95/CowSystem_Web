using System;
using System.Collections.Generic;

namespace CowSystem.Prueba
{
    public partial class Bitacora
    {
        public int IdRegistro { get; set; }
        public string Tabla { get; set; }
        public string Operacion { get; set; }
        public string Identificador { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
