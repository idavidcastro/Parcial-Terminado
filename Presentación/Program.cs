using System;
using Entidad;
using Lógica;

namespace Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal montoDinero;
            decimal valorInteres;
            int periodo, tipoTasaInteres, numeroCredito, identificacionCliente;

            Console.Write("Ingrese el número del crédito: ");
            numeroCredito = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la identificacion del cliente: ");
            identificacionCliente = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el monto de dinero a solicitar: ");
            montoDinero = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese el tipo de tasa de interes (1-compuesto ; 2-simple): ");
            tipoTasaInteres = int.Parse(Console.ReadLine());
            while (tipoTasaInteres < 1 || tipoTasaInteres > 2)
            {
                Console.Write("ERROR! Digite un número de tipo correcto: ");
                tipoTasaInteres = int.Parse(Console.ReadLine());
            }
            Console.Write("Ingrese el valor de la tasa de interes: ");
            valorInteres = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese el periodo de prestamo (AÑOS): ");
            periodo = int.Parse(Console.ReadLine());

            Creditos creditos;

            if (tipoTasaInteres == 1)
            {
                creditos = new CreditoTipoCompuesto(numeroCredito, identificacionCliente, montoDinero, tipoTasaInteres, valorInteres, periodo);
                creditos.CalcularCredito();
                CreditoService creditoService = new();
                creditoService.Guardar(creditos);
                var respuesta = creditoService.Visualizar();
                if (respuesta.Error)
                {
                    Console.WriteLine(respuesta.Mensaje);
                }
                else
                {
                    foreach (var item in respuesta.Creditos)
                    {
                        Console.WriteLine($"{item.NumeroCredito};{item.IdentificacionCliente};{item.TipoTasaInteres};{item.MontoDinero};{item.ValorInteres};{item.Periodo};{item.CapitalFinal}");
                    }
                }

            }
            else if (tipoTasaInteres == 2)
            {
                creditos = new CreditoTipoSimple(numeroCredito, identificacionCliente, montoDinero, tipoTasaInteres, valorInteres, periodo);
                creditos.CalcularCredito();
                CreditoService creditoService = new();
                creditoService.Guardar(creditos);
                var respuesta = creditoService.Visualizar();
                if (respuesta.Error)
                {
                    Console.WriteLine(respuesta.Mensaje);
                }
                else
                {
                    foreach (var item in respuesta.Creditos)
                    {
                        Console.WriteLine($"{item.NumeroCredito};{item.IdentificacionCliente};{item.TipoTasaInteres};{item.MontoDinero};{item.ValorInteres};{item.Periodo};{item.CapitalFinal}");
                    }
                }
            }


        }
    }
}