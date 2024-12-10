using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracion.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string NombrePais { get; set; }

        public ICollection<Movimiento> MovimientosDestino { get; set; }
        public ICollection<Movimiento> MovimientosOrigen { get; set; }
    }
}