using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ControlMigracion.Models
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int IdViajero { get; set; }
        public DateTime Fecha { get; set; }
        public int Destino { get; set; }
        public int Origen { get; set; }
        public string TipoSolicitud { get; set; }
        public int IdUsuario { get; set; }

        public Viajero Viajero { get; set; }
        public Pais PaisDestino { get; set; }
        public Pais PaisOrigen { get; set; }
        public Usuario Usuario { get; set; }
    }
}