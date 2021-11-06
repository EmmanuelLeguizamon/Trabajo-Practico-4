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




            cliente.Validacion();

            Console.WriteLine("1.Solicitar un servicio de correspondencia o encomienda.");
            Console.WriteLine("2.Consultar el estado de un servicio.");
            Console.WriteLine("3.Consultar el estado de cuenta.");
            Console.WriteLine("4.Finalizar");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("Ingrese su opción");



            Console.ReadLine();
        }
    }
}
