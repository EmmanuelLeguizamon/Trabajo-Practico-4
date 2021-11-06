using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var cliente = new Cliente();
            var precio = new Precios();
            //Generación de files
            cliente.DatosClientes();

            do
            {
                cliente.corporativo = false;
                cliente.Validacion();
                
                if(cliente.corporativo == false)
                {
                    Console.WriteLine("\nEl CUIT ingresado no forma parte de nuestra base de clientes corporativos. Intente nuevamente." +
                        "\nPresione una tecla para continuar.\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("----------------------------");
                    Console.WriteLine($"| Bienvenido cliente {cliente.nrocliente} |");
                    Console.WriteLine("----------------------------");
                }
                Console.ReadLine();
                Console.Clear();

            } while (cliente.corporativo == false);



                Console.WriteLine("1.Solicitar un servicio de correspondencia o encomienda.");
                Console.WriteLine("2.Consultar el estado de un servicio.");
                Console.WriteLine("3.Consultar el estado de cuenta.");
                Console.WriteLine("4.Finalizar");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("Ingrese su opción");

            /*
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Solicitar();
                    break;

                case "2":
                    ConsultaServicio();
                    break;

                case "3":
                    ConsultarCuenta();
                    break;

                case "4":
                    Salir();
                    break;

                default:
                    Console.WriteLine("No ingresó una opción válida");
                    break;
            }
            */

            Console.ReadLine();

        }
    }
}
