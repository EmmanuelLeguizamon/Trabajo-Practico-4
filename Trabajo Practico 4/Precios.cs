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

        public double RetiroPuerta { get; } = 700;

        public double EntregaPuerta { get; } = 800;

        public double precioBruto { get; set; }

        public double Urgente { get; } = 1.15;

        public double precioFinal { get; set; }


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
        public double CalcularPrecioServicio(string tipoPaquete, int alcance, bool urgente, bool retiroPuerta, bool entregaPuerta)
        {
            precioBruto = 0;

            if (tipoPaquete == "Sobres hasta 500 gramos")
                precioBruto = 200;
            if (tipoPaquete == "Bultos hasta 10 kilogramos")
                precioBruto = 300;
            if (tipoPaquete == "Bultos hasta 20 kilogramos")
                precioBruto = 400;
            if (tipoPaquete == "Bultos hasta 30 kilogramos")
                precioBruto = 500;
            Console.WriteLine($"El valor por ser {tipoPaquete} es: {precioBruto}");
            if (alcance == 1)
                precioBruto += 100;
            if (alcance == 2)
                precioBruto += 200;
            if (alcance == 3)
                precioBruto += 300;
            if (alcance == 4)
                precioBruto += 400;
            Console.WriteLine($"El valor del {tipoPaquete} y su alcance es: {precioBruto}");
            if (entregaPuerta)
                precioBruto += EntregaPuerta;
            if (retiroPuerta)
                precioBruto += RetiroPuerta;
            if (urgente)
                precioBruto = precioBruto * Urgente;


            Console.WriteLine($"El valor con adicionales es: {precioBruto}");

            precioFinal = precioBruto * IVA;

            return precioFinal;
        }

        public void CalcularPrecioServicio(string tipoPaquete, int alcance, bool urgente, bool retiroPuerta, bool entregaPuerta, int regionInternacional)
        {
            //hacer
        }

    }
}
