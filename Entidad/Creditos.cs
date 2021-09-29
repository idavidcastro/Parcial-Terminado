using System;

namespace Entidad
{
    public abstract class Creditos
    {
        public decimal MontoDinero { get; set; }
        public decimal ValorInteres { get; set; }
        public int Periodo { get; set; }
        public int IdentificacionCliente { get; set; }
        public int TipoTasaInteres { get; set; }
        public int NumeroCredito { get; set; }
        public decimal CapitalFinal { get; set; }


        public abstract void CalcularCredito();


    }
}