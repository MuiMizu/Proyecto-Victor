using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;
using Modelo;

namespace ClassLibrary1
{
    public class ClienteBLL
    {
        private ClienteDAL clienteDAL = new ClienteDAL();

        public bool RegistrarCliente(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.NombreCompleto) ||
                string.IsNullOrEmpty(cliente.Correo) ||
                string.IsNullOrEmpty(cliente.Contraseña))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            return clienteDAL.RegistrarCliente(cliente);
        }

        public bool ValidarCredenciales(string nombreCompleto, string contraseña)
        {
            return clienteDAL.ValidarCredenciales(nombreCompleto, contraseña);
        }
    }
}
