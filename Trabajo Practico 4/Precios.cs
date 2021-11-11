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

        public double RetiroPuerta { get; } = 70;

        public double EntregaPuerta { get; } = 80;

        public double precioBruto { get; set; }

        public double precioAlcance { get; set; }//

        public double precioAlcanceInt { get; set; }

        public double Urgente { get; } = 1.15;

        public double precioFinal { get; set; }

        //Precio envios paises limitrofes
        public double precioPL { get; } = 2500;

        //precio envios paises resto america latina
        public double precioRAM { get; } = 4500;

        //precio envios america norte
        public double precioAN { get; } = 7500;

        //precio envios europa
        public double precioEU { get; } = 10000;

        //precio envios asia
        public double precioAS { get; } = 13500;

        public void DatosTarifas()
        {
            //Verificao si el file existe, en caso de no existir se crea.
            if (!File.Exists(@"\ClientesCorporativos.txt"))
            {
                using (var writer = new StreamWriter(@"\ClientesCorporativos.txt")) //append: false --> permite sobreescribir
                {
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                }
            }
        }


        //método calcular precio
        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool entregaPuerta, bool retiroPuerta, bool urgente)
        {
            precioBruto = 0;
            precioAlcance = 0;//

            if (tipoPaquete == "Sobres hasta 500 gramos")
            {
                precioBruto = 200;
            }
            else if (tipoPaquete == "Bultos hasta 10 kilogramos")

            {
                precioBruto = 300;
            }
            else if (tipoPaquete == "Bultos hasta 20 kilogramos")
            {
                precioBruto = 400;
            }
            else if (tipoPaquete == "Bultos hasta 30 kilogramos")
            {
                precioBruto = 500;
            }

            Console.WriteLine("-------------------Valores del envío-------------------");
            Console.WriteLine();

            Console.WriteLine($"1){tipoPaquete}: ${precioBruto}");
            Console.WriteLine();

            if (alcance == 1)
            {
                precioAlcance = 150;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma localidad: ${precioAlcance}");
                Console.WriteLine();
            }
            else if (alcance == 2)
            {
                precioAlcance = 250;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma provincia: ${precioAlcance}");
                Console.WriteLine();
            }
            else if (alcance == 3)
            {
                precioAlcance = 350;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma región: ${precioAlcance}");
                Console.WriteLine();
            }
            else
            {
                precioAlcance = 450;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en distinta región: ${precioAlcance}");
                Console.WriteLine();
            }
            //  Console.WriteLine($"El valor del {tipoPaquete} y su alcance es: {precioBruto}");

            Console.WriteLine("Servicios adicionales:");
            Console.WriteLine();
            if (entregaPuerta == true)
            {
                Console.WriteLine($"3)Entrega en domicilio: Si - ${EntregaPuerta}");
                precioBruto += EntregaPuerta;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("3)Entrega en domicilio: No");
                Console.WriteLine();
            }

            if (retiroPuerta == true)
            {
                Console.WriteLine($"4)Retiro en domicilio: Si - ${RetiroPuerta}");
                precioBruto += RetiroPuerta;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("4)Retiro en domicilio: No");
                Console.WriteLine();
            }

            if (urgente == true)
            {
                Console.WriteLine($"5)Urgente: Si - ${precioBruto * (Urgente - 1)}");
                precioBruto = precioBruto * Urgente;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("5)Urgente: No");
                Console.WriteLine();
            }

            Console.WriteLine($"Valor del envío sin IVA: ${precioBruto}");
            Console.WriteLine();

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool entregaPuerta, bool retiroPuerta, int alcanceEnvioInt, bool urgente)
        {
            precioBruto = 0;
            precioAlcance = 0;//
            precioAlcanceInt = 0;

            if (tipoPaquete == "Sobres hasta 500 gramos")
            {
                precioBruto = 200;
            }
            else if (tipoPaquete == "Bultos hasta 10 kilogramos")

            {
                precioBruto = 300;
            }
            else if (tipoPaquete == "Bultos hasta 20 kilogramos")
            {
                precioBruto = 400;
            }
            else if (tipoPaquete == "Bultos hasta 30 kilogramos")
            {
                precioBruto = 500;
            }

            Console.WriteLine("-------------------Valores del envío-------------------");
            Console.WriteLine();

            Console.WriteLine($"1){tipoPaquete}: ${precioBruto}");
            Console.WriteLine();

            if (alcance == 1)
            {
                precioAlcance = 150;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma localidad: ${precioAlcance}");
                Console.WriteLine();
            }
            else if (alcance == 2)
            {
                precioAlcance = 250;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma provincia: ${precioAlcance}");
                Console.WriteLine();
            }
            else if (alcance == 3)
            {
                precioAlcance = 350;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en la misma región: ${precioAlcance}");
                Console.WriteLine();
            }
            else
            {
                precioAlcance = 450;
                precioBruto += precioAlcance;
                Console.WriteLine($"2)Envío en distinta región: ${precioAlcance}");
                Console.WriteLine();
            }


            Console.WriteLine("Servicios adicionales:");
            Console.WriteLine();
            if (entregaPuerta == true)
            {
                Console.WriteLine($"3)Entrega en domicilio: Si - ${EntregaPuerta}");
                precioBruto += EntregaPuerta;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("3)Entrega en domicilio: No");
                Console.WriteLine();
            }

            if (retiroPuerta == true)
            {
                Console.WriteLine($"4)Retiro en domicilio: Si - ${RetiroPuerta}");
                precioBruto += RetiroPuerta;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("4)Retiro en domicilio: No");
                Console.WriteLine();
            }

            if (alcanceEnvioInt == 1)
            {
                Console.WriteLine($"5)Envío a país limítrofe: ${precioPL}");
                precioBruto += precioPL;
                Console.WriteLine();
            }
            else if (alcanceEnvioInt == 2)
            {
                Console.WriteLine($"5)Envío a país resto de América Latina: ${precioRAM}");
                precioBruto += precioRAM;
                Console.WriteLine();
            }
            else if (alcanceEnvioInt == 3)
            {
                Console.WriteLine($"5)Envío a país de América del Norte: ${precioAN}");
                precioBruto += precioAN;
                Console.WriteLine();
            }
            else if (alcanceEnvioInt == 4)
            {
                Console.WriteLine($"5)Envío a país de Europa: ${precioEU}");
                precioBruto += precioEU;
                Console.WriteLine();
            }
            else if (alcanceEnvioInt == 5)
            {
                Console.WriteLine($"5)Envío a país de Asia: ${precioAS}");
                precioBruto += precioAS;
                Console.WriteLine();
            }

            if (urgente == true)
            {
                Console.WriteLine($"6)Urgente: Si - ${precioBruto * (Urgente - 1)}");
                precioBruto = precioBruto * Urgente;
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("6)Urgente: No");
                Console.WriteLine();
            }

            Console.WriteLine($"Valor del envío sin IVA: ${precioBruto}");
            Console.WriteLine();

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

    }
}

