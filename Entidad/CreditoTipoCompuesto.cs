using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class CreditoTipoCompuesto : Creditos
    {
        public CreditoTipoCompuesto()
        {
        }

        public CreditoTipoCompuesto(int numeroCredito, int identificacionCliente, decimal montoDinero, int tipoTasaInteres, decimal valorInteres, int periodo)
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

            decimal elevacion;
            ValorInteres /= 100;

            elevacion = (decimal)Math.Pow((double)(1 + ValorInteres), Periodo);

            CapitalFinal = MontoDinero * elevacion;

            Console.WriteLine($"El capital final es: {CapitalFinal}");
        }

    }
}
