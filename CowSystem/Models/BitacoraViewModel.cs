using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CowSystem.Models
{
    public class BitacoraViewModel
    {
        [Key]
        public int IdRegistro { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        [DisplayName("Tabla")]
        public string Tabla { get; set; }
        [DisplayName("Operación")]
        public string Operacion { get; set; }
        [DisplayName("Identificador")]
        public string Identificador { get; set; }
        [DisplayName("Usuario")]
        public string Usuario { get; set; }
        [DisplayName("FechaRegistro")]
        public string FechaRegistro { get; set; }
    }
}