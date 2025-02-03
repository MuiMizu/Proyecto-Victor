using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public bool RegistrarPago(Pago pago)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Pago (PagoID, MontoAnterior, InteresPagado, MontoAbonado, MontoPagado, MontoRestante) " +
                                   "VALUES (@PagoID, @MontoAnterior, @InteresPagado,@MontoAbonado, @MontoPagado, @MontoRestante,@PagoID)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@PagoID", pago.PagoID);
                    command.Parameters.AddWithValue("@MontoAnterior", pago.MontoAnterior);
                    command.Parameters.AddWithValue("@InteresPagado", pago.InteresPagado);
                    command.Parameters.AddWithValue("@MontoAbonado", pago.MontoAbonado);
                    command.Parameters.AddWithValue("@MontoPagado", pago.MontoPagado);
                    command.Parameters.AddWithValue("@MontoRestante", pago.MontoRestante);

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



        public decimal ObtenerFondoDisponible(Fondo fondo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 1 MontoDisponible FROM Fondo";
                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        fondo.MontoDisponible = (decimal)reader["MontoDisponible"];
                        return fondo.MontoDisponible;
                    }
                    else
                    {
                        return -1;
                    }
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


        public bool RegistrarPrestamo(Prestamo prestamo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Prestamos 
                    (ClienteID, Monto, PlazoEnMeses, InteresAplicado, MontoTotal, Estado) 
                    VALUES (@ClienteID, @Monto, @PlazoEnMeses, @InteresAplicado, @MontoTotal, @Estado);
                    SELECT SCOPE_IDENTITY();";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ClienteID", Sesion.ClienteId);
                    command.Parameters.AddWithValue("@Monto", prestamo.Monto);
                    command.Parameters.AddWithValue("@PlazoEnMeses", prestamo.PlazoMeses);
                    command.Parameters.AddWithValue("@InteresAplicado", prestamo.Interes);
                    command.Parameters.AddWithValue("@MontoTotal", prestamo.MontoTotal);
                    command.Parameters.AddWithValue("@Estado", prestamo.Estado);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        prestamo.PrestamoID = Convert.ToInt32(result); 
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el préstamo: " + ex.Message);
                return false;
            }

        }

        public bool CargarDatosPago (Prestamo prestamo, Cliente cliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT 
                    NombreCompleto, 
                    Correo, 
                    Sueldo, 
                    Direccion, 
                    Telefono, 
                    Garantia, 
                    p.Monto,  
                    p.PlazoEnMeses,  
                    p.InteresAplicado,  
                    p.MontoTotal
                FROM Clientes c
                JOIN Prestamos p ON c.ClienteID = p.ClienteID
                WHERE p.PrestamoID = @PrestamoID;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        Sesion.NombreCompleto = reader["NombreCompleto"].ToString();
                        Sesion.Correo = reader["Correo"].ToString();
                        cliente.Sueldo = (decimal)reader["Sueldo"];
                        cliente.Direccion = reader["Direccion"].ToString();
                        cliente.Telefono = reader["Telefono"].ToString();
                        cliente.Garantia = reader["Garantia"].ToString();
                        prestamo.Monto = (decimal)reader["Monto"];
                        prestamo.PlazoMeses = (int)reader["PlazoEnMeses"];
                        prestamo.Interes = (decimal)reader["InteresAplicado"];
                        prestamo.MontoTotal = (decimal)reader["MontoTotal"];

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CargarCuotas (Prestamo prestamo,Cuota cuota)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT COUNT(*) AS PagosHechos FROM Pagos p JOIN Prestamos pr ON p.PrestamoID = pr.PrestamoID WHERE pr.PrestamoID = @PrestamoID;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        cuota.NumeroCuota = Convert.ToInt32(reader["PagosHechos"]);
                        
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool RegistrarPago(Prestamo prestamo, Pago pago)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string procedureName = "RegistroPago";
                    SqlCommand command = new SqlCommand(procedureName, connection);
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);
                    command.Parameters.AddWithValue("@MontoPagado", pago.MontoPagado);
                    command.Parameters.AddWithValue("@InteresPagado", pago.InteresPagado);
                    command.Parameters.AddWithValue("@MontoAbonado", pago.MontoAbonado);
                    command.Parameters.AddWithValue("@Mora", pago.Mora);


                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el pago: " + ex.Message);
                return false;
            }
        }
        public bool CargarMontos(Prestamo prestamo, Pago pago)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT TOP 1 MontoPagado, MontoRestante, MontoAbonado  
                                    FROM Pagos pa 
                                    JOIN Prestamos p ON pa.PrestamoID = p.PrestamoID 
                                    WHERE p.PrestamoID = @PrestamoID
                                    ORDER BY PagoID DESC;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        pago.MontoRestante = Convert.ToDecimal(reader["MontoRestante"]);
                        pago.MontoPagado = Convert.ToDecimal(reader["MontoPagado"]);
                        pago.MontoAbonado = Convert.ToDecimal(reader["MontoAbonado"]);
                        return true;
                    }
                    else
                    {
                        pago.MontoRestante = prestamo.Monto;
                        pago.MontoPagado = 0;
                        pago.MontoAbonado = 0;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public bool CargarAbonoTotal(Prestamo prestamo, Pago pago)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT SUM(MontoAbonado) AS AbonoTotal FROM Pagos WHERE PrestamoID = @PrestamoID;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        pago.AbonoTotal = reader.IsDBNull(0) ? 0 : reader.GetDecimal(0);
                        return true;
                    }
                    else
                    {
                        pago.AbonoTotal = 0; 
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool RegistrarAbono(Prestamo prestamo, Recalculo recalculo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"INSERT INTO Recalculo (PrestamoID, Monto, Cuotas, Interes, MontoTotal) 
                                   VALUES (@PrestamoID, @Monto, @Cuotas, @Interes, @MontoTotal);";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);
                    command.Parameters.AddWithValue("@Monto", recalculo.Monto);
                    command.Parameters.AddWithValue("@Cuotas", recalculo.Cuotas);
                    command.Parameters.AddWithValue("@Interes", recalculo.Interes);
                    command.Parameters.AddWithValue("@MontoTotal", recalculo.Total);


                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar el pago: " + ex.Message);
                return false;
            }
        }
        public bool CargarRecalculo (Prestamo prestamo, Recalculo recalculo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @" SELECT TOP 1 Monto, Interes, MontoTotal, Cuotas
                                      FROM Recalculo 
                                      WHERE PrestamoID = @PrestamoID
                                      ORDER BY RecalculoID DESC;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        recalculo.Monto = (decimal)reader["Monto"];
                        recalculo.Interes = (decimal)reader["Interes"];
                        recalculo.Total = (decimal)reader["MontoTotal"];
                        recalculo.Cuotas = (int)reader["Cuotas"];

                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool CargarMoras(Prestamo prestamo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT COUNT(Mora) AS Moras
                                    FROM Pagos
                                    WHERE PrestamoID = @PrestamoID AND Mora = 1;;";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        prestamo.Moras = (int)reader["Moras"];
                        return true;
                    }
                    else
                    {
                        prestamo.Moras = 0;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public DataTable ObtenerPagos(Prestamo prestamo)
        {
            DataTable dtClientes = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"SELECT MontoAnterior, InteresPagado, MontoAbonado, MontoPagado, MontoRestante,
                            CASE 
                                WHEN Mora = 1 THEN 'Retrasado'
                                ELSE 'Pagado'
                            END AS EstadoPago
                            FROM Pagos
                            WHERE PrestamoID = @PrestamoID;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PrestamoID", prestamo.PrestamoID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command)) 
                        {
                            adapter.Fill(dtClientes);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener pagos: " + ex.Message);
            }
            return dtClientes;
        }

        public DataTable ObtenerReporte()
        {
            try
            {  
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string query = "SELECT * FROM VistaClientesMorosos"; 

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener datos desde la vista: " + ex.Message);
            }
        }
    }

}
