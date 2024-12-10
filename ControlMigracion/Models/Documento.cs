using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracion.Models
{
    public class Documento
    {
        public int Id { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int IdViajero { get; set; }

        public Viajero Viajero { get; set; }
    }
}