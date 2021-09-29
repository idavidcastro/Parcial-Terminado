using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CreditoConsultaResponse
    {
        public List<Creditos> Creditos { get; set; }
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public CreditoConsultaResponse(List<Creditos> credito)
        {
            Creditos = credito;
            Error = false;
        }
        public CreditoConsultaResponse(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }
}
