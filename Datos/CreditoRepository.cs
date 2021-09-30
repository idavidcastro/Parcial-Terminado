using Entidad;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class CreditoRepository
    {
        public string ruta = "Creditos.txt";

        public void Guardar(Creditos creditos)
        {
            FileStream file = new(ruta, FileMode.Append);
            StreamWriter writer = new(file);
            writer.WriteLine($"{creditos.NumeroCredito};{creditos.IdentificacionCliente}; {creditos.TipoTasaInteres};{creditos.MontoDinero};{creditos.ValorInteres};{creditos.Periodo};{creditos.CapitalFinal}");

            writer.Close();
            file.Close();
        }
        public List<Creditos> Visualizar()
        {
            List<Creditos> creditos = new();
            using (StreamReader reader = new(ruta))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    Creditos credito = Mapear(linea) ;

                    creditos.Add(credito);
                }
            }
            return creditos;
        }
        private static Creditos Mapear(string linea)
        {
            Creditos credito;
            string[] dato = linea.Split(';');
            if (int.Parse(dato[2]) == 1)
            {
                credito = new CreditoTipoCompuesto();
            }
            else if (int.Parse(dato[2]) == 2)
            {
                credito = new CreditoTipoSimple();
            }

            credito.NumeroCredito = int.Parse(dato[0]);
            credito.IdentificacionCliente = int.Parse(dato[1]);
            credito.TipoTasaInteres = int.Parse(dato[2]);
            credito.MontoDinero = decimal.Parse(dato[3]);
            credito.ValorInteres = decimal.Parse(dato[4]);
            credito.Periodo = int.Parse(dato[5]);
            credito.CapitalFinal = decimal.Parse(dato[6]);

            return credito;
        }

        public void Eliminar(string id)
        {
            List<Creditos> creditos = Visualizar();
            File.Delete(ruta);

            foreach (var item in creditos)
            {
                if (!item.NumeroCredito.Equals(id))
                {
                    Guardar(item);
                }
            }
        }
        public void Modificar(string id, Creditos personaNew)
        {
            List<Creditos> personas = Visualizar();
            File.Delete(ruta);

            foreach (var item in personas)
            {
                if (!item.IdentificacionCliente.Equals(id))
                {
                    Guardar(item);
                }
                else
                {
                    Guardar(personaNew);
                }
            }
        }
    }
}
