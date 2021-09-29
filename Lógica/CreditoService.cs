using Datos;
using Entidad;
using System;

namespace Lógica
{
    public class CreditoService
    {
        CreditoRepository creditoRepository;
        public CreditoService()
        {
            creditoRepository = new CreditoRepository();
        }

        public string Guardar(Creditos creditos)
        {
            try
            {
                creditoRepository.Guardar(creditos);
                return "Se han guardado corrctamente";
            }
            catch (Exception e)
            {

                return "ERROR!" + e.Message;
            }
        }
    }
}