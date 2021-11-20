using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    public class Precios
    {
        public double IVA { get; } = 1.21;
        public double precioBruto { get; set; }
        //public double precioAlcance { get; set; }
        //public double precioAlcanceInt { get; set; }
        public double precioFinal { get; set; }

        Dictionary<string, double> DiccionarioPrecios = new Dictionary<string, double>();

        public void DatosTarifas()
        {
            using (StreamReader lector = new StreamReader(@"Precios.txt"))
            {
                string line;

                while ((line = lector.ReadLine()) != null)
                {
                    string[] linea = line.Split(';');
                    double precio = double.Parse(linea[1]);
                    string detalle = linea[0];
                    DiccionarioPrecios.Add(detalle, precio);
                }

                lector.Close();

                //PRUEBA DE GENERACIÓN
                /*foreach (KeyValuePair<string, double> cliente__ in DiccionarioPrecios)
                {
                    Console.WriteLine(cliente__.Key + "\t" + cliente__.Value);
                }
                Console.ReadKey();

                bool hasValue = DiccionarioPrecios.TryGetValue("Entrega Puerta", out double EntregaPuerta);

                if (hasValue)
                {
                    Console.WriteLine($"Ingreso Válido, ");
                }
                else
                    Console.WriteLine("Error");
                Console.ReadKey();*/
            }
        }


        //método calcular precio
        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool entregaPuerta, bool retiroPuerta, bool urgente)
        {
            DatosTarifas();

            precioBruto = 0;
            //precioAlcance = 0;

            precioBruto = DiccionarioPrecios[tipoPaquete];

            Console.WriteLine("-------------------Valores del envío-------------------\n");

            Console.WriteLine($"1){tipoPaquete}: ${precioBruto}");

            if (alcance == 1)
            {
                precioBruto += DiccionarioPrecios["Alcance1"];
                Console.WriteLine($"2)Envío en la misma localidad: ${DiccionarioPrecios["Alcance1"]}");
            }
            else if (alcance == 2)
            {
                precioBruto += DiccionarioPrecios["Alcance2"];
                Console.WriteLine($"2)Envío en la misma provincia: ${DiccionarioPrecios["Alcance2"]}");
            }
            else if (alcance == 3)
            {
                precioBruto += DiccionarioPrecios["Alcance3"];
                Console.WriteLine($"2)Envío en la misma región: ${DiccionarioPrecios["Alcance3"]}");
            }
            else
            {
                precioBruto += DiccionarioPrecios["Alcance4"];
                Console.WriteLine($"2)Envío en distinta región: ${DiccionarioPrecios["Alcance4"]}");
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Servicios adicionales:");
            Console.WriteLine();
            if (entregaPuerta == true)
            {
                Console.WriteLine($"3)Entrega en domicilio: Si - ${DiccionarioPrecios["Entrega Puerta"]}");
                precioBruto += DiccionarioPrecios["Entrega Puerta"];
            }
            else
                Console.WriteLine("3)Entrega en domicilio: No");

            if (retiroPuerta == true)
            {
                Console.WriteLine($"4)Retiro en domicilio: Si - ${DiccionarioPrecios["Retiro Puerta"]}");
                precioBruto += DiccionarioPrecios["Retiro Puerta"];
            }
            else
                Console.WriteLine("4)Retiro en domicilio: No");

            if (urgente == true)
            {
                Console.WriteLine($"5)Urgente: Si - ${precioBruto * (DiccionarioPrecios["Urgente"] - 1)}");
                precioBruto = precioBruto * DiccionarioPrecios["Urgente"];
            }
            else
                Console.WriteLine("5)Urgente: No");

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Valor del envío sin IVA: ${precioBruto}");
            Console.WriteLine();

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool entregaPuerta, bool retiroPuerta, int alcanceEnvioInt, bool urgente)
        {
            DatosTarifas();

            precioBruto = 0;

            precioBruto = DiccionarioPrecios[tipoPaquete];

            Console.WriteLine("-------------------Valores del envío-------------------\n");

            Console.WriteLine($"1){tipoPaquete}: ${precioBruto}\n");

            if (alcance == 1)
            {
                precioBruto += DiccionarioPrecios["Alcance1"];
                Console.WriteLine($"2)Envío en la misma localidad: ${DiccionarioPrecios["Alcance1"]}");
            }
            else if (alcance == 2)
            {
                precioBruto += DiccionarioPrecios["Alcance2"];
                Console.WriteLine($"2)Envío en la misma provincia: ${DiccionarioPrecios["Alcance2"]}");
            }
            else if (alcance == 3)
            {
                precioBruto += DiccionarioPrecios["Alcance3"];
                Console.WriteLine($"2)Envío en la misma región: ${DiccionarioPrecios["Alcance3"]}");
            }
            else
            {
                precioBruto += DiccionarioPrecios["Alcance4"];
                Console.WriteLine($"2)Envío en distinta región: ${DiccionarioPrecios["Alcance4"]}");
            }

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Servicios adicionales:");
            Console.WriteLine();
            if (entregaPuerta == true)
            {
                Console.WriteLine($"3)Entrega en domicilio: Si - ${DiccionarioPrecios["Entrega Puerta"]}");
                precioBruto += DiccionarioPrecios["Entrega Puerta"];
            }
            else
                Console.WriteLine("3)Entrega en domicilio: No");

            if (retiroPuerta == true)
            {
                Console.WriteLine($"4)Retiro en domicilio: Si - ${DiccionarioPrecios["Retiro Puerta"]}");
                precioBruto += DiccionarioPrecios["Retiro Puerta"];
            }
            else
                Console.WriteLine("4)Retiro en domicilio: No");

            if (alcanceEnvioInt == 1)
            {
                Console.WriteLine($"5)Envío a país limítrofe: ${DiccionarioPrecios["Pais Limitrofe"]}");
                precioBruto += DiccionarioPrecios["Pais Limitrofe"];
            }
            else if (alcanceEnvioInt == 2)
            {
                Console.WriteLine($"5)Envío a país resto de América Latina: ${DiccionarioPrecios["America Latina"]}");
                precioBruto += DiccionarioPrecios["America Latina"];
            }
            else if (alcanceEnvioInt == 3)
            {
                Console.WriteLine($"5)Envío a país de América del Norte: ${DiccionarioPrecios["America Norte"]}");
                precioBruto += DiccionarioPrecios["America Norte"];
            }
            else if (alcanceEnvioInt == 4)
            {
                Console.WriteLine($"5)Envío a país de Europa: ${DiccionarioPrecios["Europa"]}");
                precioBruto += DiccionarioPrecios["Europa"];
            }
            else if (alcanceEnvioInt == 5)
            {
                Console.WriteLine($"5)Envío a país de Asia: ${DiccionarioPrecios["Asia"]}");
                precioBruto += DiccionarioPrecios["Asia"];
            }

            if (urgente == true)
            {
                Console.WriteLine($"6)Urgente: Si - ${precioBruto * (DiccionarioPrecios["Urgente"] - 1)}");
                precioBruto = precioBruto * DiccionarioPrecios["Urgente"];
            }
            else
                Console.WriteLine("6)Urgente: No");

            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine($"Valor del envío sin IVA: ${precioBruto}\n");

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

    }
}

