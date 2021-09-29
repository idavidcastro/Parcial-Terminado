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

            }
            else if (tipoTasaInteres == 2)
            {
                creditos = new CreditoTipoSimple(numeroCredito, identificacionCliente, montoDinero, tipoTasaInteres, valorInteres, periodo);
                creditos.CalcularCredito();
                CreditoService creditoService = new();
                creditoService.Guardar(creditos);
            }


        }
        private static void Consultar()
        {
            Console.Clear();
            var respuesta = CreditoService.Consultar();
            if (respuesta.Error)
            {
                Console.WriteLine(respuesta.Mensaje);
            }
            else
            {
                foreach (var item in respuesta.Personas)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine("-------------------------");
                }
            }

        }
        private static void ConsultaNumeroCredito()
        {
            Console.Clear();
            Console.WriteLine("ingrese el numero del credito a modificar datos.");
            BusquedaNumero();
        }

        private static void BusquedaNumero()
        {
            throw new NotImplementedException();
        }

        private static void Modificar()
        { 
            Console.Clear();
            Console.WriteLine("Información de la Persona a Modificar");
            int(periodo, tipoTasaInteres, identificacionCliente) = BusquedaNumero();
            decimal(montoDinero, valorInteres)= BusquedaNumero();
            if (IsFind)
            {
                Console.WriteLine("ingrese los Nuevos Datos ");
                Persona persona = Guardar();
                Console.Write("Ingrese la identificacion del cliente: ");
                string mensaje = personaService.Modificiar(identificacionCliente, persona);
                Console.WriteLine(mensaje);
                Console.Write("Ingrese el monto de dinero a solicitar: ");
                string mensaje = personaService.Modificiar(montoDinero, persona);
                Console.WriteLine(mensaje);
                Console.Write("Ingrese el tipo de tasa de interes (1-compuesto ; 2-simple): ");
                string mensaje = personaService.Modificiar(tipoTasaInteres, persona);
                Console.WriteLine(mensaje);
            }

        }
    }
}