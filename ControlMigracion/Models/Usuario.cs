using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControlMigracion.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string CorreoElectronico { get; set; }
        public string Rol { get; set; }
    }
}