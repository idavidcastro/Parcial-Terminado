using System;
using System.Collections.Generic;
using System.IO;
using Entidad;

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
                    string[] dato = linea.Split(';');
                    Creditos credito;
                    
                    {
                        creditos.NumeroCredito = int.Parse(dato[0]),
                        creditos.IdentificacionCliente = int.Parse(dato[1]),
                        creditos.TipoTasaInteres = int.Parse(dato[2]),
                        creditos.MontoDinero = decimal.Parse(dato[3]),
                        creditos.ValorInteres = decimal.Parse(dato[4]),
                        creditos.Periodo = int.Parse(dato[5]),
                        creditos.CapitalFinal = decimal.Parse(dato[6])

                    };
                    creditos.Add(credito);
                }
            }
            return creditos;
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
