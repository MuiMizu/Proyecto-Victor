using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public static class Sesion
    {
        public static int ClienteId { get; set; }
        public static string NombreCompleto { get; set; }

        public static string Correo { get; set; }

    }

    public class Cliente
    {

        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Garantia { get; set; }
        public decimal Sueldo { get; set; }
        public string Contraseña { get; set; }
    }
}
