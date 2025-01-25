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

    public class Prestamo
    {
        public decimal Monto { get; set; }
        public int PlazoMeses { get; set; }
        public decimal Interes { get; set; }
        public int InteresPor { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoPorCuota { get; set; }
        public string Estado { get; set; }

        public decimal CalcularInteres(int numeroCuotas)
        {
            if (numeroCuotas >= 1 && numeroCuotas <= 3)
                return 10; 
            else if (numeroCuotas >= 4 && numeroCuotas <= 6)
                return 8; 
            else if (numeroCuotas >= 7 && numeroCuotas <= 12)
                return 7; 
            else
                return 5; 
        }

        public void CalcularTotales()
        {
            this.Interes = this.Monto * (this.CalcularInteres(this.PlazoMeses) / 100);
            this.MontoTotal = this.Monto + this.Interes;
            this.MontoPorCuota = this.MontoTotal / this.PlazoMeses;
        }
        public List<Cuota> GenerarTablaCuotas(decimal montoTotal, int plazoMeses, decimal montoPorCuota, decimal interes)
        {
            List<Cuota> cuotas = new List<Cuota>();

            decimal interesPorCuota = interes/plazoMeses;
            for (int i = 1; i <= plazoMeses; i++)
            {
                cuotas.Add(new Cuota
                {
                    NumeroCuota = i,
                    MontoCuota = montoPorCuota,
                    InteresCuota = interesPorCuota,
                    TotalCuota = montoPorCuota + (interesPorCuota / plazoMeses)
                });
            }

            return cuotas;
        }
    }
    public class Cuota
    {
        public int NumeroCuota { get; set; }
        public decimal MontoCuota { get; set; }
        public decimal InteresCuota { get; set; }
        public decimal TotalCuota { get; set; }

    }
}
