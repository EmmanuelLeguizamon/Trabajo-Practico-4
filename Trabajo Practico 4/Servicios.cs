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
            [1] = "Buenos Aires",
            [2] = "CABA",
            [3] = "Chaco",
            [4] = "Chubut",
            [5] = "Cordoba",
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
            [16] = "San Luis",
            [17] = "San Juan",
            [18] = "Santa Cruz",
            [19] = "Santa Fe",
            [20] = "Santiago del Estero",
            [21] = "Salta",
            [22] = "Tierra del Fuego",

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
            [8] = "España - Madrid",
            [9] = "Japon - Tokio",
            [10] = "China - Pekin",
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
                Console.WriteLine("Paso 1 - Seleccione el tipo de paquete a entregar");
                Console.WriteLine();
                foreach (KeyValuePair<int, string> opcion in tipoPaquete)
                {
                                      
                    Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    Console.WriteLine();
                }

                paquete = Console.ReadLine();

                //Valido la data ingresada por el usuario
                if (string.IsNullOrWhiteSpace(paquete))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
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
                    Console.WriteLine("Por favor ingrese una de las opciones");
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
            Console.WriteLine($"Eligió: {tipoPaqueteSeleccionado}");
            Console.WriteLine();

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//
            
            Console.Clear();//
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
                Console.WriteLine("Paso 2 - Seleccione el tipo de entrega a realizar");
                Console.WriteLine();

                foreach (KeyValuePair<int, string> opcion in tipoEntrega)
                {
                
                    Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    Console.WriteLine();//
                }

                entrega = Console.ReadLine();

                //Valido la data ingresada por el usuario
                if (string.IsNullOrWhiteSpace(entrega))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
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
                    Console.WriteLine("Por favor ingrese una de las opciones");
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
            Console.WriteLine($"Eligió: {tipoEntregaSeleccionada}");
            Console.WriteLine();

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//
            
            Console.Clear();//

            bool flagC = false;
            string provinciaDeOrigen;

            Console.WriteLine("Paso 3 - Seleccione la provincia de ORIGEN");
            Console.WriteLine();
            do
            {
                foreach (KeyValuePair<int, string> opcion in provinciaNacional)
                {
                    Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                }

                provinciaDeOrigen = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(provinciaDeOrigen))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
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
                    Console.WriteLine("Por favor ingrese una de las opciones");
                    Console.WriteLine();
                }

                else
                {
                    flagC = true;
                }

            } while (flagC == false);

            provinciaDeOrigenSeleccionada = provinciaNacional[opcionProvincia];

            Console.WriteLine();
            Console.WriteLine($"Eligió {provinciaDeOrigenSeleccionada} como ORIGEN");
            Console.WriteLine();

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//

            Console.Clear();//

            if (tipoEntregaSeleccionada == "Nacional")
            {
                bool flagF = false;
                string provinciaDeDestino;

                Console.WriteLine("Paso 4 - Seleccione la provincia/estado de DESTINO");
                Console.WriteLine();
                do
                {
                    foreach (KeyValuePair<int, string> opcion in provinciaNacional)
                    {

                        Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    }

                    provinciaDeDestino = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDeDestino))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor, no ingrese valores vacíos");
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
                        Console.WriteLine("Por favor ingrese una de las opciones");
                        Console.WriteLine();
                    }

                    else
                    {
                        flagF = true;
                    }

                } while (flagF == false);

                provinciaDeDestinoSeleccionada = provinciaNacional[opcionProvincia];

                Console.WriteLine();
                Console.WriteLine($"Eligió {provinciaDeDestinoSeleccionada} como DESTINO");
                Console.WriteLine();

                Console.WriteLine("------Enter para continuar------");
                Console.ReadKey();//

                Console.Clear();//
            }

            else
            {
                bool flagG = false;
                string provinciaDestinoInternacional;

                Console.WriteLine("Paso 4 - Ingrese la provincia/estado de DESTINO");

                do
                {

                    foreach (KeyValuePair<int, string> opcion in provinciaInternacional)
                    {
                        Console.WriteLine($"{opcion.Key} - {opcion.Value}");
                    }

                    provinciaDestinoInternacional = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(provinciaDestinoInternacional))
                    {
                        Console.WriteLine();
                        Console.WriteLine("Por favor, no ingrese valores vacíos");
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
                        Console.WriteLine("Por favor ingrese una de las opciones");
                        Console.WriteLine();

                    }

                    else
                    {
                        flagG = true;
                    }

                } while (flagG == false);

                provinciaDestinoInternacional = provinciaInternacional[opcionProvincia];

                Console.WriteLine();
                Console.WriteLine($"Eligió {provinciaDestinoInternacional} como DESTINO");
                Console.WriteLine();

                Console.WriteLine("------Enter para continuar------");
                Console.ReadKey();//

                Console.Clear();//
            }

            bool flagA = false;
            bool flagB = false;
            string codigoPostalIngresado;

            Console.WriteLine("Paso 5.1 - Ingrese el Código Postal de origen (SOLO NUMEROS)");
            Console.WriteLine();

            do
            {
                codigoPostalIngresado = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(codigoPostalIngresado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                }

                else if (!int.TryParse(codigoPostalIngresado, out codigoPostalValidado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un Código Postal valido.");
                    Console.WriteLine();
                }

                else
                {
                    flagA = true;
                }

            } while (flagA == false);

         

            codigoPostalOrigen = codigoPostalValidado;

            Console.WriteLine();
            Console.WriteLine("Paso 5.2 - Ingrese el Código Postal de destino (SOLO NUMEROS)");
            Console.WriteLine();
            do
            {
                codigoPostalIngresado = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(codigoPostalIngresado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                }

                else if (!int.TryParse(codigoPostalIngresado, out codigoPostalValidado))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un Código Postal valido.");
                    Console.WriteLine();
                }

                else
                {
                    flagB = true;
                }

            } while (flagB == false);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//

            Console.Clear();//

            codigoPostalDestino = codigoPostalValidado;

            string direccionDeOrigen;
            bool flagD = false;

            do
            {
                
                Console.WriteLine("Paso 6.1 - Ingrese la dirección de ORIGEN");

                direccionDeOrigen = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(direccionDeOrigen))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
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
                Console.WriteLine();
                Console.WriteLine("Paso 6.2 - Ingrese la dirección de DESTINO");

                direccionDeDestino = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(direccionDeDestino))
                {
                    Console.WriteLine();
                    Console.WriteLine("Por favor, no ingrese valores vacíos");
                    Console.WriteLine();
                }

                else
                {
                    flagE = true;
                }

            } while (flagE == false);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//

            Console.Clear();//


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
                Console.WriteLine("¿Desea hacer el envío con entrega a domicilio? Su costo adicional es de $80. Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);
                /*Console.WriteLine($"¿Quiere que sea entregado a domicilio? De ser así, el valor adicional es de $80");
                Console.WriteLine();*/
                Console.WriteLine();

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }

                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado al domicilio");
                    entregaPuerta = true;
                    flag1 = true;
                    Console.WriteLine();
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado a la sucursal de DESTINO más cercana");
                    entregaPuerta = false;
                    flag1 = true;
                    Console.WriteLine();
                }


            } while (!flag1);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//
            
            Console.Clear();//

            bool flag2 = false;
            do
            {

                //Console.WriteLine($"¿El despacho será realizado desde el domicilio del remitente? De ser así, el valor adicional es de $700");
                
                Console.WriteLine("¿Desea hacer el despacho desde su domicilio? El valor adicional es de $70. Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);
                Console.WriteLine();

                if (tecla.Key != ConsoleKey.S && tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El despacho será realizado desde su domicilio");
                    retiroPuerta = true;
                    flag2 = true;
                    Console.WriteLine();
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El despacho será realizado desde la sucursal");
                    retiroPuerta = false;
                    flag2 = true;
                    Console.WriteLine();
                }


            } while (!flag2);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();//
           
            Console.Clear();//

            bool flag3 = false;
            do
            {

                //Console.WriteLine($"¿Desea que el envío sea realizado de forma urgente? El adicional es de 15% sobre el valor total del envío.");
                Console.WriteLine("¿Desea que el envío sea urgente? El adicional es de un 15% sobre el valor del envío. Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);
                Console.WriteLine();

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
                    Console.WriteLine();
                }
                else if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado de forma normal");
                    urgente = false;
                    flag3 = true;
                    Console.WriteLine();
                }

            } while (!flag3);

            Console.WriteLine("------Enter para continuar------");
            Console.ReadKey();
            
            Console.Clear();//

            //llama a método calcular precio
            var precio = new Precios();

            if (tipoEntregaSeleccionada == "Nacional")
            {
                precioFinal = precio.CalcularPrecioServicio(tipoPaqueteSeleccionado, alcanceEnvío, urgente, retiroPuerta, entregaPuerta);

                Console.WriteLine($"El precio final del servicio solicitado es ${precioFinal}");

                bool flag4 = false;
                do
                {
                    Console.WriteLine("Desea confirmar? Si(S) / No(N)");
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

        //METODO PARA VALIDAR SIMBOLOS
        /*  public static bool hasSpecialChar2(string input)
          {
              string specialChar = @"|¡!#$%&/()`^=¿?»«@£§€{}.,;:[]+-~`'°<>_";
              foreach (var item in specialChar)
              {
                  if (input.Contains(item)) return true;
              }

              return false;
          } */
        public void mostrarDetalle()
        {
            //TODO
            //función que devuelve el detalle del servicio
        }

    }
}