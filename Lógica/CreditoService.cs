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

        public CreditoConsultaResponse Visualizar()
        {
            try
            {
                return new CreditoConsultaResponse(creditoRepository.Visualizar());
            }
            catch (Exception e)
            {
                return new CreditoConsultaResponse("ERROR!" + e.Message);
            }
        }

        public string Eliminar(string id)
        {
            try
            {
                creditoRepository.Eliminar(id);
                return "Se elimino correctamente";
            }
            catch (Exception e)
            {
                return "Error al guardar: " + e.Message;
            }
        }
    }
}