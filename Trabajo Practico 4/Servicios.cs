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

        public bool urgente { get; set; }

        public bool retiroPuerta { get; set; }

        public bool entregaPuerta { get; set; }

        public int alcanceEnvío { get; set; }

        public string direccionOrigen { get; set; }

        public string direccionDestino { get; set; }

        public int codigoPostalOrigen { get; set; }

        public int codigoPostalDestino { get; set; }

        public string regionProvinciaOrigen { get; set; }

        public string tipoEntregaSeleccionada { get; set; }

        public string tipoPaqueteSeleccionado { get; set; }

        public string provinciaDeOrigenSeleccionada { get; set; }

        public string provinciaDeDestinoSeleccionada { get; set; }

        public double precioFinal { get; set; }

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

        Dictionary<int, string> provinciaNacional = new Dictionary<int, string>()
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
            [23] = "Tucuman",
            [24] = "CABA"

        };

        Dictionary<int, string> provinciaInternacional = new Dictionary<int, string>()
        {
            [1] = "Brasil - San Pablo",
            [2] = "Uruguay - Montevideo",
            [3] = "Paraguay - Asuncion",
            [4] = "Colombia - Antioquia",
            [5] = "Peru - Lima",
            [6] = "Ecuador - Quito",
            [7] = "Estados Unidos - California",
            [8] = "China - Pekin",
            [9] = "Japon - Tokio",
            [10] = "España - Madrid"
        };

        List<string> regionNorte = new List<string>()
        {
            "Chaco",
            "Salta",
            "Catamarca",
            "Formosa",
            "Jujuy",
            "Misiones",
            "Santiago del Estero",
            "Tucuman",
            "Corrientes"
        };

        List<string> regionCentro = new List<string>()
        {
            "Cordoba",
            "Entre Rios",
            "La Pampa",
            "La Rioja",
            "Mendoza",
            "San Juan",
            "San Luis",
            "Santa Fe"

        };

        List<string> regionSur = new List<string>()
        {
            "Chubut",
            "Neuquen",
            "Rio Negro",
            "Santa Cruz",
            "Tierra Del Fuego"
        };


        List<string> regionMetropolitana = new List<string>()
        {
            "Buenos Aires",
            "CABA"
        };

        List<string> paisesLimitrofes = new List<string>()
        {
            "Brasil",
            "Uruguay",
            "Paraguay"
        };

        List<string> restoAmericaLatina = new List<string>()
        {
            "Colombia",
            "Peru",
            "Ecuador"
        };

        List<string> americaDelNorte = new List<string>()
        {
            "Estados Unidos"
        };

        List<string> europa = new List<string>()
        {
            "España"
        };

        List<string> asia = new List<string>()
        {
            "Japon",
            "China"
        };

        //Se debe trabajar en la forma de guardar el input del usuario por la ubicación para recoger el pedido
        //TODO

        int codigoPostalValidado;

        public void pedirDatosOrigen()
        {

            //TODO pedir dirección y altura


        }

        //Agrupar las provincias en regiones
        //TODO


        //Selecciona el usuario el peso del paquete a enviar

        int opcionPaquete;

        public void elegirTipoPaquete()
        {
            bool flag = false;
            string paquete;
            //string tipoPaqueteSeleccionado;

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

            tipoPaqueteSeleccionado = tipoPaquete[opcionPaquete];

            //Devuelvo la información seleccionada para el tipo de entrega
            Console.WriteLine();
            Console.WriteLine($"Ustéd seleccionó la opción de paquete: {tipoPaqueteSeleccionado}");
        }

        //Selecciona el usuario si desea una entrega nacional o internacional

        int opcionEntrega;
        int opcionProvincia;

        //output LOCAL - BULTO MAYOR A 10KG
        public void elegirTipoEntrega()
        {
            bool flag = false;
            string entrega;
            string tipoEntregaSeleccionada;

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

            tipoEntregaSeleccionada = tipoEntrega[opcionEntrega];

            //Devuelvo la información seleccionada para el tipo de entrega
            Console.WriteLine();
            Console.WriteLine($"Ustéd seleccionó la opción de entrega: {tipoEntregaSeleccionada}");
            Console.WriteLine();

            bool flagC = false;
            string provinciaDeOrigen;

            Console.WriteLine("Por favor ingrese la provincia de origen");

            do
            {
                foreach (KeyValuePair<int, string> opcion in provinciaNacional)
                {


                    Console.WriteLine($"Presione '{opcion.Key}' para la provincia de: {opcion.Value}");
                }

                provinciaDeOrigen = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(provinciaDeOrigen))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor que no sea nulo");
                    Console.WriteLine();
                }

                else if (!int.TryParse(provinciaDeOrigen, out opcionProvincia))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor numérico");
                    Console.WriteLine();
                }

                else if (opcionProvincia <= 0 || opcionProvincia > 24)
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un valor válido dentro de las opciones");
                    Console.WriteLine();
                }

                else
                {
                    flagC = true;
                }

            } while (flagC == false);

            provinciaDeOrigenSeleccionada = provinciaNacional[opcionProvincia];

            Console.WriteLine();
            Console.WriteLine($"Ustéd seleccionó la provincia de origen: {provinciaDeOrigenSeleccionada}");
            Console.WriteLine();

            if (tipoEntregaSeleccionada == "Nacional")
            {
                bool flagF = false;
                string provinciaDeDestino;

                Console.WriteLine("Por favor ingrese la provincia de destino nacional ");

                do
                {
                    foreach (KeyValuePair<int, string> opcion in provinciaNacional)
                    {

                        Console.WriteLine($"Presione '{opcion.Key}' para la provincia de: {opcion.Value}");
                    }

                    provinciaDeDestino = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDeDestino))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor que no sea nulo");
                        Console.WriteLine();
                    }

                    else if (!int.TryParse(provinciaDeDestino, out opcionProvincia))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor numérico");
                        Console.WriteLine();
                    }

                    else if (opcionProvincia <= 0 || opcionProvincia > 24)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor válido dentro de las opciones");
                        Console.WriteLine();
                    }

                    else
                    {
                        flagF = true;
                    }

                } while (flagF == false);

                provinciaDeDestinoSeleccionada = provinciaNacional[opcionProvincia];

                Console.WriteLine();
                Console.WriteLine($"Usted seleccionó la provincia de destino: {provinciaDeDestinoSeleccionada}");
                Console.WriteLine();
            }

            else
            {
                bool flagG = false;
                string provinciaDestinoInternacional;

                Console.WriteLine("Por favor ingrese la provincia de destino internacional");

                do
                {

                    foreach (KeyValuePair<int, string> opcion in provinciaInternacional)
                    {
                        Console.WriteLine($"Presione '{opcion.Key}' para la provincia de: {opcion.Value}");
                    }

                    provinciaDestinoInternacional = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDestinoInternacional))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor que no sea nulo");
                        Console.WriteLine();
                    }

                    else if (!int.TryParse(provinciaDestinoInternacional, out opcionProvincia))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor numérico");
                        Console.WriteLine();
                    }

                    else if (opcionProvincia <= 0 || opcionProvincia > 10)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor ingrese un valor válido dentro de las opciones");
                        Console.WriteLine();
                    }

                    else
                    {
                        flagG = true;
                    }

                } while (flagG == false);

                provinciaDestinoInternacional = provinciaInternacional[opcionProvincia];

                Console.WriteLine();
                Console.WriteLine($"Ustéd seleccionó la provincia de origen: {provinciaDestinoInternacional}");
                Console.WriteLine();
            }

            bool flagA = false;
            bool flagB = false;
            string codigoPostalIngresado;

            Console.WriteLine("Por favor ingrese el codigo postal del lugar de origen");



            do
            {

                codigoPostalIngresado = Console.ReadLine();

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

                else
                {
                    flagA = true;
                }

            } while (flagA == false);

            codigoPostalOrigen = codigoPostalValidado;

            Console.WriteLine("Por favor ingrese el codigo postal del lugar de entrega");


            do
            {
                codigoPostalIngresado = Console.ReadLine();

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

                else
                {
                    flagB = true;
                }

            } while (flagB == false);

            codigoPostalDestino = codigoPostalValidado;

            string direccionDeOrigen;
            bool flagD = false;

            do
            {
                Console.WriteLine("Por favor ingrese la dirección de origen");

                direccionDeOrigen = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(direccionDeOrigen))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese una dirección valida");
                    Console.WriteLine();
                }

                else
                {
                    flagD = true;
                }

            } while (flagD == false);


            direccionOrigen = direccionDeOrigen;

            string direccionDeDestino;
            bool flagE = false;

            do
            {
                Console.WriteLine("Por favor ingrese la dirección de destino");

                direccionDeDestino = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(direccionDeDestino))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese una dirección valida");
                    Console.WriteLine();
                }

                else
                {
                    flagE = true;
                }

            } while (flagE == false);


            direccionDestino = direccionDeDestino;

            //calculo alcance del envío comparando regiones ( alcance: 1 = local / 2=provincial / 3=regional / 4=nacional )

            if (tipoEntregaSeleccionada == "Nacional")
            {

                if (regionCentro.Contains(provinciaDeOrigenSeleccionada) && regionCentro.Contains(provinciaDeDestinoSeleccionada) ||
                regionNorte.Contains(provinciaDeOrigenSeleccionada) && regionNorte.Contains(provinciaDeDestinoSeleccionada) ||
                regionSur.Contains(provinciaDeOrigenSeleccionada) && regionSur.Contains(provinciaDeDestinoSeleccionada) ||
                regionMetropolitana.Contains(provinciaDeOrigenSeleccionada) && regionMetropolitana.Contains(provinciaDeDestinoSeleccionada))
                {

                    if (provinciaDeDestinoSeleccionada == provinciaDeOrigenSeleccionada)
                    {
                        if (codigoPostalDestino == codigoPostalOrigen)
                            alcanceEnvío = 1;
                        else
                            alcanceEnvío = 2;
                    }
                    else
                        alcanceEnvío = 3;
                }
                else
                    alcanceEnvío = 4;
            }
            else
            {
                if (regionMetropolitana.Contains(provinciaDeOrigenSeleccionada))
                {
                    if (provinciaDeOrigenSeleccionada == "CABA")
                        alcanceEnvío = 1;
                    else
                        alcanceEnvío = 3;
                }
                else
                    alcanceEnvío = 4;

                // AGREGAR CUADROS TARIFARIOS DE ENVÍO INTERNACIONAL
            }

            bool flag1 = false;
            do
            {


                Console.WriteLine($"El envío a destino ¿es entrega en domicilio? De ser así, el valor adicional es de $80");
                Console.WriteLine("¿Desea hacer el envío con entrega a domicilio? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);


                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }

                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado al domicilio del destinatario.");
                    entregaPuerta = true;
                    flag1 = true;
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado a la sucursal");
                    entregaPuerta = false;
                    flag1 = true;
                }


            } while (!flag1);

            bool flag2 = false;
            do
            {

                Console.WriteLine($"¿El despacho será realizado desde el domicilio del remitente? De ser así, el valor adicional es de $700");
                Console.WriteLine("¿Desea hacer el despacho desde el domicilio? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El despacho será realizado desde el domicilio del remitente");
                    retiroPuerta = true;
                    flag2 = true;
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El despacho será realizado desde la sucursal");
                    retiroPuerta = false;
                    flag2 = true;
                }


            } while (!flag2);

            bool flag3 = false;
            do
            {

                Console.WriteLine($"¿Desea que el envío sea realizado de forma urgente? El adicional es de 15% sobre el valor total del envío.");
                Console.WriteLine("¿Desea que el envío sea urgente? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado de forma urgente");
                    urgente = true;
                    flag3 = true;
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado de forma normal");
                    urgente = false;
                    flag3 = true;
                }

            } while (!flag3);


            //llama a método calcular precio
            var precio = new Precios();

            if (tipoEntregaSeleccionada == "Nacional")
            {
                precioFinal = precio.CalcularPrecioServicio(tipoPaqueteSeleccionado, alcanceEnvío, urgente, retiroPuerta, entregaPuerta);

                Console.WriteLine($"El precio final del servicio solicitado es ${precioFinal}");

                bool flag4 = false;
                do
                {
                    Console.WriteLine("Desea confirmar? S/N");
                    var tecla = Console.ReadKey(intercept: true);

                    if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                    {
                        Console.WriteLine("Ingrese S/N");
                        continue;
                    }


                    if (tecla.Key == ConsoleKey.S)
                    {
                        Console.WriteLine("El envío fue confirmado exitosamente");
                        //MOSTRAR CÓDIGO DE SEGUIMIENTO
                        //GRABAR EL SERVICIO
                        flag4 = true;
                    }
                    else if (tecla.Key == ConsoleKey.N)
                    {
                        Console.WriteLine("El envío fue cancelado");
                        //VOLVER AL MENU PRINCIPAL
                        flag4 = true;
                    }

                } while (!flag4);
            }
            //else
            //     precio.CalcularPrecioServicio(tipoPaqueteSeleccionado, alcanceEnvío, urgente, retiroPuerta, entregaPuerta);
            //AGREGAR PARÁMETRO RE REGIÓN INTERNACIONAL


        }


        public void mostrarDetalle()
        {
            //TODO
            //función que devuelve el detalle del servicio
        }

    }
}

