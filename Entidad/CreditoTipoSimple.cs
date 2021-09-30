using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CreditoTipoSimple : Creditos
    {
        public CreditoTipoSimple()
        {
        }

        public CreditoTipoSimple(int numeroCredito, int identificacionCliente, decimal montoDinero, int tipoTasaInteres, decimal valorInteres, int periodo)
        {
            MontoDinero = montoDinero;
            ValorInteres = valorInteres;
            Periodo = periodo;
            IdentificacionCliente = identificacionCliente;
            TipoTasaInteres = tipoTasaInteres;
            NumeroCredito = numeroCredito;
        }

        public override void CalcularCredito()
        {

            ValorInteres /= 100;

            CapitalFinal = MontoDinero * (1 + ValorInteres * Periodo);

            Console.WriteLine($"El capital final es: {CapitalFinal}");
        }

    }
}