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
            var logistica = new Logistica();

            
            //Generación de files
            cliente.DatosClientes();
            logistica.DatosCodigosdeSeg();
            /*
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
            */

            logistica.ConsultarCodSeg();
            logistica.codseguim = 1;
            logistica.MostrarCodigoGenerado();




            /*
            var opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Solicitar();
                    break;

                case "2":
                    Estado_de_servicio.ConsultarEstadoServicio();
                    break;

                case "3":
                    ConsultarCuenta();
                    //muestra 2 opciones disponibles
                    Console.WriteLine("1.Ver historial de servicios.");
                    Console.WriteLine("2.Consultar saldo de cuenta.");
                    Console.WriteLine("3.Volver atrás.");

                    var opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            // genera file de historial de solicitudes
                            Estado_de_servicio.SolicitudesDeServicio();
                            cliente.ConsultarHistorialCuenta(cliente.nrocliente);
                            break;

                        case "2":
                            // genera file de facturas
                            Facturacion.ServiciosFacturados();
                            cliente.ConsultarSaldoCuenta(cliente.nrocliente);
                            break;
                        case "3":
                            //volver a menu principal
                            break;
                        default:
                            Console.WriteLine("No ingresó una opción válida" +
                                "\nPresione una tecla para continuar.\n");
                            break;
                    }
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
