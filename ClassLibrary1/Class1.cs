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
            if (string.IsNullOrEmpty(Sesion.NombreCompleto) ||
                string.IsNullOrEmpty(Sesion.Correo) ||
                string.IsNullOrEmpty(cliente.Contraseña))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            return clienteDAL.RegistrarCliente(cliente);
        }

        public bool RegistrarDatos(Cliente cliente)
        {
            if (string.IsNullOrEmpty(cliente.Telefono) ||
                string.IsNullOrEmpty(cliente.Direccion) ||
                string.IsNullOrEmpty(cliente.Garantia) ||
                string.IsNullOrEmpty(Convert.ToString(cliente.Sueldo)))
            {
                throw new ArgumentException("Todos los campos son obligatorios.");
            }

            return clienteDAL.RegistrarDatos(cliente);
        }
          
        public bool IniciarSesion(string correo, string contraseña)
        {
            int clienteId = clienteDAL.ValidarCredenciales(correo, contraseña);

            if (clienteId > 0)
            {
             
                return true;
            }
            else
            {

                return false;
            }
        }

        public decimal ObtenerFondoDisponible(Fondo fondo)
        {
            return clienteDAL.ObtenerFondoDisponible(fondo);
        }

        public bool ActualizarFondoDisponible(decimal nuevoMonto)
        {
            return clienteDAL.ActualizarFondoDisponible(nuevoMonto);
        }

        public bool RegistrarPrestamo(Prestamo prestamo)
        {
            return clienteDAL.RegistrarPrestamo(prestamo);
        }

        public bool CargarDatosPago(Prestamo prestamo, Cliente cliente)
        {
            return clienteDAL.CargarDatosPago(prestamo, cliente);
        }

        public bool CargarCuotas(Prestamo prestamo, Cuota cuota)
        {
            return clienteDAL.CargarCuotas(prestamo, cuota);
        }
    }
}
