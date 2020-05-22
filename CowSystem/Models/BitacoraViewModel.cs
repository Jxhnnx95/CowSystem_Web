using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CowSystem.Models
{
    public class BitacoraViewModel
    {
        [Key]
        public int IdRegistro { get; set; }
        [DisplayName("Ganado")]
        public string Ganado { get; set; }
        [DisplayName("Ganado")]
        public string GanadoURL { get; set; }
        [DisplayName("Operación")]
        public string TipoBalance { get; set; }
        [DisplayName("Operación")]
        public string TipoBalanceURL { get; set; }
        [DisplayName("Factura")]
        public string Gasto { get; set; }
        [DisplayName("Factura")]
        public string GastoURL { get; set; }
        [DisplayName("Usuario")]
        public string Usuario { get; set; }
        [DisplayName("Usuario")]
        public string UsuarioURL { get; set; }
        [DisplayName("FechaRegistro")]
        public string FechaRegistro { get; set; }
    }
}