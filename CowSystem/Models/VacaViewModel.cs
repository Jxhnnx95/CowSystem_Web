using CowSystem.Code;
using CowSystem.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CowSystem.Models
{
    public class VacaViewModel
    {
        [Key]
        public int IdGanado { get; set; }

        [DisplayName("Identificador")]
        [Required(ErrorMessage ="Este campo debe ser rellenado")]
        [MaxLength(100,ErrorMessage ="Debe tener menos de 100 caracteres")]
        public string Codigo { get; set; }

        [DisplayName("Sexo")]
        public int? Tipo { get; set; }

        [DisplayName("Sexo")]
        public string TipoString { get; set; }

        [DisplayName("Estado")]
        public int? Estado { get; set; }

        [DisplayName("Estado")]
        public string EstadoString { get; set; }

        [DisplayName("Ingreso al sistema")]
        public DateTime FechaIngreso { get; set; }

        [DisplayName("Ingreso al sistema")]
        public string FechaIngresoString { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "Este campo debe ser rellenado")]
        public DateTime? FechaNacimiento { get; set; }

        [DisplayName("Fecha de nacimiento")]
        public string FechaNacimientoString { get; set; }

        [DisplayName("Fecha de salida")]
        public DateTime FechaSalida { get; set; }

        [DisplayName("Fecha de salida")]
        public string FechaSalidaString { get; set; }

        [DisplayName("Edad")]
        public string EdadString { get; set; }

        [DisplayName("Peso (Kg)")]
        public double? Peso { get; set; }

        [DisplayName("Peso (Kg)")]
        public string PesoString { get; set; }

        [DisplayName("Valor inicial")]
        [Required(ErrorMessage = "Este campo debe ser rellenado")]
        public double? Valor { get; set; }

        [DisplayName("Valor")]
        public string ValorString { get; set; }

        [DisplayName("Precio (Kg)")]
        public double? ValorPeso { get; set; }

        [DisplayName("Precio (Kg)")]
        public string ValorPesoString { get; set; }
        [DisplayName("Partos")]
        public int? Partos { get; set; }

        [DisplayName("Partos")]
        public string PartosString { get; set; }

        [DisplayName("Madre")]
        [Required(ErrorMessage = "Este campo debe ser rellenado")]
        public int? IdMadre { get; set; }
        [DisplayName("Madre")]
        public string MadreString { get; set; }
        [DisplayName("Madre")]
        public string MadreUrl { get; set; }

        [DisplayName("Padre")]
        [Required(ErrorMessage = "Este campo debe ser rellenado")]
        public int? IdPadre { get; set; }
        [DisplayName("Padre")]
        public string PadreString { get; set; }
        [DisplayName("Padre")]
        public string PadreUrl { get; set; }

        [DisplayName("Actualización")]
        public string UltimaActualizacion { get; set; }

        public ICollection<Evento> EventList { get; set; }
        public ICollection<TipoGanado> TipoGanadoList { get; set; }
        public ICollection<EstadoGanado> EstadoGanadoList { get; set; }
        public ICollection<Ganado> VacasList { get; set; }
        public ICollection<Ganado> TorosList { get; set; }
    }
}