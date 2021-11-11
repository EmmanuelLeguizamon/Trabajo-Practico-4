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
            var servicio = new Servicios();
            var estadodeserv = new Estado_de_servicio();


            //Generación de files con casos forzados *NECESARIO que ejecute al principio*
            // cliente.DatosClientes();
            //logistica.DatosCoddeSeg();



            //Validación del nro de cliente (consulta con clase cliente unicamente)
            /*  do
              {
                  cliente.corporativo = false;
                  cliente.Validacion();

                  if (cliente.corporativo == false)
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

              } while (cliente.corporativo == false);*/


            //Menu, disponible si pasa la validación de cliente

            Console.WriteLine("1.Solicitar un servicio de correspondencia o encomienda.");
            Console.WriteLine("2.Consultar el estado de un servicio.");
            Console.WriteLine("3.Consultar el estado de cuenta.");
            Console.WriteLine("4.Finalizar");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Ingrese su opción");

            //Ingreso de opción
            var opcion = Console.ReadLine();

            //Switch de opciones con sus clases y métodos
            switch (opcion)
            {
                case "1":
                    servicio.mostrarDetalle();
                    servicio.elegirTipoPaquete();
                    servicio.elegirTipoEntrega();

                    Console.ReadKey();
                    break;

                /*case "2":
                    Estado_de_servicio.ConsultarEstadoServicio();
                    break;*/

                case "3":
                    //ConsultarCuenta();
                    //muestra 2 opciones disponibles
                    Console.WriteLine("1.Ver historial de servicios.");
                    Console.WriteLine("2.Consultar saldo de cuenta.");
                    Console.WriteLine("3.Volver atrás.");

                    opcion = Console.ReadLine();
                    switch (opcion)
                    {
                        case "1":
                            // genera file de historial de solicitudes
                            Estado_de_servicio.SolicitudesDeServicio();
                            estadodeserv.ConsultarHistorialCuenta(cliente.nrocliente);
                            break;

                        case "2":
                            // genera file de facturas
                            Facturacion.DatosFacturacion();
                            estadodeserv.ConsultarSaldoCuenta(cliente.nrocliente);
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


                default:
                    Console.WriteLine("No ingresó una opción válida");
                    break;
            }


            //Finaliza con la creación de los files en base a la información recopilada durante la ejecución, para que el programa reanude donde dejó
            // logistica.GenerarFile();*/



            Console.ReadLine();

        }
    }
}

