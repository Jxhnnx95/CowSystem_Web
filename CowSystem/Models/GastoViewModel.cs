using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CowSystem.Models
{
    public class GastoViewModel
    {
        [Key]
        public int IdGasto { get; set; }
        [DisplayName("Fecha")]
        [Required]
        public DateTime Fecha { get; set; }
        [DisplayName("Fecha")]
        public string FechaString { get; set; }
        [DisplayName("Factura")]
        [MaxLength(50, ErrorMessage = "Debe tener menos de 50 caracteres")]
        public string Factura { get; set; }
        [DisplayName("Proveedor")]
        [MaxLength(50, ErrorMessage = "Debe tener menos de 50 caracteres")]
        public string Proveedor { get; set; }
        [DisplayName("Monto")]
        [Required]
        public double Monto { get; set; }
        [DisplayName("Monto")]
        public string MontoString { get; set; }
        [DisplayName("Descripción")]
        [MaxLength(50, ErrorMessage = "Debe tener menos de 50 caracteres")]
        public string Descripcion { get; set; }
        [DisplayName("Actualización")]
        public string UltimaActualizacion { get; set; }
    }
}