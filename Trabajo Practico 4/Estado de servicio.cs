using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    class Estado_de_servicio
    {
        //en class Estado_de_servicio

        //verifico si el file existe, sino se crea
        public static void SolicitudesDeServicio()
        {
            //Verificao si el file existe, en caso de no existir se crea.
            if (!File.Exists(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\SolicitudesDeServicio.txt"))
            {
                using (var writer = new StreamWriter(@"SolicitudesDeServicio.txt"))
                {
                    //formato: cuit cliente; cod servicio; estado; monto
                    writer.WriteLine("40395;10589;recibido;3000");
                    writer.WriteLine("40395;10432;tránsito;4500");
                    writer.WriteLine("40395;10946;cerrado;1800");
                    writer.WriteLine("18285;10049;tránsito;1200");
                    writer.WriteLine("18285;10501;tránsito;7000");
                    writer.WriteLine("18285;10689;cerrado;2000");
                    writer.WriteLine("14330;10054;recibido;6000");
                    writer.WriteLine("14330;11194;recibido;1200");
                    writer.WriteLine("48407;11052;cerrado;3000");
                    writer.WriteLine("48407;10784;tránsito;1800");

                    writer.Close();
                }
            }
        }

        //devuelve historial de servicios por cliente
        public static List<string> ConsultarServiciosCliente(uint cuit)
        {
            List<string> ServiciosCliente = new List<string>();

            using (StreamReader lector = new StreamReader(@"SolicitudesDeServicio.txt"))
            {
                string line;

                while ((line = lector.ReadLine()) != null)
                {
                    if (line.Contains(cuit.ToString()))
                    {
                        ServiciosCliente.Add(line);
                    }
                }

                lector.Close();
            }

            return ServiciosCliente;
        }


        //en class

        //muestra historial de servicios
        public void ConsultarHistorialCuenta(uint cuit)
        {
            Console.WriteLine($"Historial de servicios del cliente {cuit}:");

            foreach (var item in Estado_de_servicio.ConsultarServiciosCliente(cuit))
            {
                string[] linea = item.Split(';');
                Console.WriteLine($"Código servicio: {linea[1]} \t\t Monto total: {linea[3]} \t\t Estado: {linea[2]}");
            }

            Console.ReadKey();
        }

        //muestra saldo deudor de la cuenta
        public void ConsultarSaldoCuenta(uint cuit)
        {
            Console.WriteLine($"Servicios del cliente {cuit}:");
            int servicios_pagos = 0;
            int servicios_total = 0;
            List<string> servicios_facturados = Facturacion.ConsultarFacturacionCliente(cuit);
            List<string> codigos_facturados = new List<string>();

            foreach (var item in servicios_facturados)
            {
                string[] linea = item.Split(';');
                codigos_facturados.Add(linea[2]);
            }

            //arranca con lista de todos los servicios
            foreach (var item in Estado_de_servicio.ConsultarServiciosCliente(cuit))
            {
                string[] lineaservicio = item.Split(';');

                //escribe los que no estan facurados
                if (!codigos_facturados.Contains(lineaservicio[1]))
                {
                    Console.WriteLine($"Código servicio: {lineaservicio[1]} \t\t Monto total: {lineaservicio[3]} \t\t Estado: Pendiente Facturación");
                    int monto = int.Parse(lineaservicio[3]);
                }
                //escribe los facturados 
                else
                {
                    foreach (var item2 in servicios_facturados)
                    {
                        string[] lineafactura = item2.Split(';');

                        if (lineaservicio[1] == lineafactura[2])
                        {
                            //escribe los que estan pagos
                            if (lineafactura[3] == "si")
                            {
                                Console.WriteLine($"Código servicio: {lineafactura[2]} \t\t Monto total: {lineafactura[4]} \t\t Estado: Pago");
                                int monto = int.Parse(lineafactura[4]);
                                servicios_pagos += monto;
                            }
                            else
                                Console.WriteLine($"Código servicio: {lineafactura[2]} \t\t Monto total: {lineafactura[4]} \t\t Estado: Facturado pendiente de pago");

                        }

                    }

                }

                int monto2 = int.Parse(lineaservicio[3]);
                servicios_total += monto2;

            }

            Console.WriteLine($"\nSu saldo deudor es de ${servicios_total - servicios_pagos}" +
                        "\nPresione una tecla para volver al menú principal.\n");
            Console.ReadKey();
        }

        public static void ConsultarEstadoServicio()
        {
            Console.WriteLine("Ingrese el código de seguimiento. (5 dígitos, sin guiones ni espacios)");
            int codigo = Logistica.ValidacionCodigo(Console.ReadLine());

            //falta recorrer txt y escribir el estado

            Console.WriteLine($"Estado del servicio {codigo}:       ");

        }

    }
}
