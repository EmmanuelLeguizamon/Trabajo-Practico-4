using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Trabajo_Practico_4
{
    class Servicios
    {

        //public int CodSer { get; set; }

        //public DateTime FechaSer { get; set; }

        //public int TipoServicio { get; set; }

        //public string NomApDest { get; set; }

        //public string DomDest { get; set; }

        //public string CPDest { get; set; }

        //public string CiuDest { get; set; }

        //public string EstDest { get; set; }

        //public string ProvDest { get; set; }

        //public string PaisDest { get; set; }

        //public int CUIT { get; set; }

        //public string NomApRem { get; set; }

        //public string DomRem { get; set; }

        //public string CPRem { get; set; }

        //public string CiuRem { get; set; }

        //public string EstRem { get; set; }

        //public string ProvRem { get; set; }

        //public string PaisRem { get; set; }

        //public bool EntregaPuerta { get; set; }

        //public bool RetiroPuerta { get; set; }

        //public bool EnvUrg { get; set; }

        //public decimal PrecioSinIVA { get; set; }

        //public decimal PrecioFinal { get; set; } //precio con iva

        public int codigoPostalOrigen { get; set; }

        public int codigoPostalDestino { get; set; }

        public string regionProvincia { get; set; }

        public string tipoEntregaSeleccionada { get; set; }

        public string tipoPaqueteSeleccionado { get; set; }

        public string provinciaSeleccionada { get; set; }

        Dictionary<int, string> tipoEntrega = new Dictionary<int, string>()
        {
            [1] = "Nacional",
            [2] = "Internacional"
        };

        Dictionary<int, string> tipoPaquete = new Dictionary<int, string>()
        {
            [1] = "Sobres hasta 500 gramos",
            [2] = "Bultos hasta 10 kilogramos",
            [3] = "Bultos hasta 20 kilogramos",
            [4] = "Bultos hasta 30 kilogramos"
        };

        Dictionary<int, string> provincia = new Dictionary<int, string>()
        {
            [1] = "Catamarca",
            [2] = "Chaco",
            [3] = "Chubut",
            [4] = "Cordoba",
            [5] = "Buenos Aires",
            [6] = "Corrientes",
            [7] = "Entre Rios",
            [8] = "Formosa",
            [9] = "Jujuy",
            [10] = "La Pampa",
            [11] = "La Rioja",
            [12] = "Mendoza",
            [13] = "Misiones",
            [14] = "Neuquen",
            [15] = "Rio Negro",
            [16] = "Salta",
            [17] = "San Juan",
            [18] = "San Luis",
            [19] = "Santa Cruz",
            [20] = "Santa Fe",
            [21] = "Santiago del Estero",
            [22] = "Tierra del Fuego",
            [23] = "Tucuman"
        };

        //Se debe trabajar en la forma de guardar el input del usuario por la ubicación para recoger el pedido
        //TODO

        int codigoPostalValidado;

        public void pedirDatosOrigen()
        {
            bool flag = false;
            string codigoPostalIngresado;

            Console.WriteLine("Por favor ingrese el codigo postal del lugar de retiro");

            codigoPostalIngresado = Console.ReadLine();

            do
            {
                if (string.IsNullOrWhiteSpace(codigoPostalIngresado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valór que no sea nulo");
                    Console.WriteLine();
                }

                else if (!int.TryParse(codigoPostalIngresado, out codigoPostalValidado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un codigo postal valido. ");
                    Console.WriteLine();
                }

            } while (flag == false);

            codigoPostalOrigen = codigoPostalValidado;

            //TODO pedir dirección y altura

            //TODO pedir provincia de Origen

        }

        //Agrupar las provincias en regiones
        //TODO


        //Selecciona el usuario el peso del paquete a enviar

        int opcionPaquete;

        public void elegirTipoPaquete()
        {
            bool flag = false;
            string paquete;
            string tipoPaqueteSeleccionado;

            do
            {
                foreach (KeyValuePair<int, string> opcion in tipoPaquete)
                {
                    Console.WriteLine("Seleccione el tipo de paquete a entregar: ");

                    Console.WriteLine($"Presione '{opcion.Key}' para {opcion.Value} ");
                }

                paquete = Console.ReadLine();

                //Valido la data ingresada por el usuario
                if (string.IsNullOrWhiteSpace(paquete))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valór que no sea nulo");
                    Console.WriteLine();
                }

                else if (!int.TryParse(paquete, out opcionPaquete))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor numérico");
                    Console.WriteLine();
                }

                else if (opcionPaquete != 1 && opcionPaquete != 2 && opcionPaquete != 3 && opcionPaquete != 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor válido dentro de las opciones");
                    Console.WriteLine();
                }

                else
                {
                    flag = true;
                }

            } while (flag == false);

            //Devuelvo la información seleccionada para el tipo de entrega
            Console.WriteLine();
            Console.WriteLine($"Ustéd seleccionó la opción de paquete: {tipoPaqueteSeleccionado = tipoPaquete[opcionPaquete]}");
        }


        //Selecciona el usuario si desea una entrega nacional o internacional

        int opcionEntrega;
        int opcionProvincia;

        public void elegirTipoEntrega()
        {
            bool flag = false;
            string entrega;
            string tipoEntregaSeleccionada;
            string provinciaDeEntrega;

            do
            {

                foreach (KeyValuePair<int, string> opcion in tipoEntrega)
                {
                    Console.WriteLine("Seleccione el tipo de entrega a realizar: ");

                    Console.WriteLine($"Presione '{opcion.Key}' para {opcion.Value} ");

                }

                entrega = Console.ReadLine();

                //Valido la data ingresada por el usuario
                if (string.IsNullOrWhiteSpace(entrega))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor que no sea nulo");
                    Console.WriteLine();
                }

                else if (!int.TryParse(entrega, out opcionEntrega))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor numérico");
                    Console.WriteLine();
                }

                else if (opcionEntrega != 1 && opcionEntrega != 2)
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor válido dentro de las opciones");
                    Console.WriteLine();
                }

                else
                {
                    flag = true;
                }


            } while (flag == false);

            //Devuelvo la información seleccionada para el tipo de entrega
            Console.WriteLine();
            Console.WriteLine($"Ustéd seleccionó la opción de entrega: {tipoEntregaSeleccionada = tipoEntrega[opcionEntrega]}");
            Console.WriteLine();

            if (tipoEntregaSeleccionada == "Nacional")
            {
                //El usuario debe decidir la provincia para que se determine si es Provincial , Regional o Nacional
                bool flagP = false;

                do
                {
                    foreach (KeyValuePair<int, string> opcion in provincia)
                    {

                        Console.WriteLine("Seleccione la provincia en donde desea realizar la entrega: ");

                        Console.WriteLine($"Presione '{opcion.Key}' para la provincia de: {opcion.Value}");
                    }

                    provinciaDeEntrega = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDeEntrega))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor que no sea nulo");
                        Console.WriteLine();
                    }

                    else if (!int.TryParse(provinciaDeEntrega, out opcionProvincia))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor numérico");
                        Console.WriteLine();
                    }

                    else if (opcionProvincia <= 0 || opcionProvincia > 23)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor válido dentro de las opciones");
                        Console.WriteLine();
                    }

                    else
                    {
                        flagP = true;
                    }

                } while (flagP == false);

                Console.WriteLine();
                Console.WriteLine($"Ustéd seleccionó la opción de entrega: {provinciaSeleccionada = provincia[opcionProvincia]}");
                Console.WriteLine();

                //Si el usuario elige la misma provincia en la que se encuentra el, entonces se debe preguntar si un envío es local o no con el codigo postal
                //TODO


                //Si el usuario elige internacional
                //TODO

            }
        }

        public void serviciosAdicionales()
        {
            //TODO
            //funcion que te devuelve el precio a adicionar al total en caso de decidir agregar algun servicio
        }

        public void mostrarDetalle()
        {
            //TODO
            //función que devuelve el detalle del servicio
        }

    }
}

