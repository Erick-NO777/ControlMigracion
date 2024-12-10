using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ControlMigracion.Models
{
    public class Viajero
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string SegundoNombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public string CorreoElectronico { get; set; }
        public string Genero { get; set; }
        public string Telefono { get; set; }

        public ICollection<Documento> Documentos { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}