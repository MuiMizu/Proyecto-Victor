using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2;
using static System.Collections.Specialized.BitVector32;

namespace Modelo
{
    public class ClienteDAL
    {
        private string connectionString = "Server=VMIZU\\FABIAN;Database=SistemaPrestamos;User Id=Fran;Password=12345678;";

        public bool RegistrarCliente(Cliente cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Clientes (NombreCompleto, Correo, Contraseña) " +
                                   "VALUES (@NombreCompleto, @Correo, @Contraseña)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@NombreCompleto", Sesion.NombreCompleto);
                    command.Parameters.AddWithValue("@Correo", Sesion.Correo);
                    command.Parameters.AddWithValue("@Contraseña",cliente.Contraseña);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool RegistrarDatos(Cliente cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Clientes " +
                                   "SET Telefono = @Telefono, Direccion = @Direccion, Garantia = @Garantia, Sueldo = @Sueldo " +
                                   "WHERE ClienteID = @ClienteID";
                    SqlCommand command = new SqlCommand(query, connection);

 
                    command.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    command.Parameters.AddWithValue("@Garantia", cliente.Garantia);
                    command.Parameters.AddWithValue("@Sueldo", cliente.Sueldo);
                    command.Parameters.AddWithValue("@ClienteID", Sesion.ClienteId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false; 
            }
        }
        public int ValidarCredenciales(string correo, string contraseña)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT ClienteID, NombreCompleto FROM Clientes WHERE Correo = @Correo AND Contraseña = @Contraseña";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Correo", correo);
                    command.Parameters.AddWithValue("@Contraseña", contraseña); 

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Sesion.ClienteId = (int)reader["ClienteID"];
                        Sesion.NombreCompleto = reader["NombreCompleto"].ToString();
                        return Sesion.ClienteId;
                    }
                    else
                    {
                        return -1; 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        public decimal ObtenerFondoDisponible()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 MontoDisponible FROM Fondo";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    object resultado = command.ExecuteScalar();
                    return resultado != null ? Convert.ToDecimal(resultado) : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el fondo disponible: " + ex.Message);
                return 0;
            }
        }

        public bool ActualizarFondoDisponible(decimal nuevoMonto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Fondo SET MontoDisponible = @MontoDisponible";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MontoDisponible", nuevoMonto);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al actualizar el fondo disponible: " + ex.Message);
                return false;
            }
        }

        Prestamo prestamo = new Prestamo();
        public bool RegistrarPrestamo(Prestamo prestamo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Prestamos (ClienteID, Monto, PlazoEnMeses, InteresAplicado, MontoTotal, Estado) " +
                                   "VALUES (@ClienteID, @Monto, @PlazoEnMeses, @InteresAplicado, @MontoTotal, @Estado)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ClienteID", Sesion.ClienteId);
                    command.Parameters.AddWithValue("@Monto", prestamo.Monto);
                    command.Parameters.AddWithValue("@PlazoEnMeses", prestamo.PlazoMeses);
                    command.Parameters.AddWithValue("@InteresAplicado", prestamo.Interes);
                    command.Parameters.AddWithValue("@MontoTotal", prestamo.MontoTotal);
                    command.Parameters.AddWithValue("@Estado", prestamo.Estado);

                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



    }

}
