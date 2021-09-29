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
                        NumeroCredito = int.Parse(dato[0]),
                        IdentificacionCliente = int.Parse(dato[1]),
                        TipoTasaInteres = int.Parse(dato[2]),
                        MontoDinero = decimal.Parse(dato[3]),
                        ValorInteres = decimal.Parse(dato[4]),
                        Periodo = int.Parse(dato[5]),
                        CapitalFinal = decimal.Parse(dato[6])

                    };
                    creditos.Add(credito);
                }
            }
            return creditos;
        }
    }
}
