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

        public DateTime FechaSer { get; set; }

        public int TipoServicio { get; set; }

        public string NomApDest { get; set; }

        public string DomDest { get; set; }

        public string CPDest { get; set; }

        public string CiuDest { get; set; }

        public string EstDest { get; set; }

        public string ProvDest { get; set; }

        public string PaisDest { get; set; }

        //public int CUIT { get; set; }

        public string NomApRem { get; set; }

        public string DomRem { get; set; }

        public string CPRem { get; set; }

        public string CiuRem { get; set; }

        public string EstRem { get; set; }

        public string ProvRem { get; set; }

        public string PaisRem { get; set; }

        public bool EntregaPuerta { get; set; }

        public bool RetiroPuerta { get; set; }

        public bool EnvUrg { get; set; }

        // public decimal PrecioSinIVA { get; set; }

        //  public decimal PrecioFinal { get; set; } //precio con iva

        List<string> Pais = new List<string>() { "ARGENTINA", "BRASIL", "URUGUAY", "MEXICO", "COLOMBIA", "ESTADOS UNIDOS", "ESPAÑA", "JAPON" };

        List<string> RegNorte = new List<string>() { "CHACO" };

        List<string> RegSur = new List<string>() { "RIO NEGRO" };

        List<string> RegMetropolitana = new List<string>() { "BUENOS AIRES", "CABA" };

        List<string> RegCentro = new List<string>() { "CORDOBA" };

        List<string> Ciudad = new List<string>() { "VIEDMA", "RESISTENCIA", "CABA", "VICENTE LOPEZ", "CORDOBA CAPITAL" };

        List<string> ProvEst = new List<string>() { "RIO NEGRO", "CHACO", "BUENOS AIRES", "CABA", "CORDOBA" };


        string ingreso;


        public void Solicitar()
        {

            Console.WriteLine("Tipo de servicio a realizar: ");
            Console.WriteLine("1. Sobre (hasta 500 g) ");
            Console.WriteLine("2. Bulto (hasta 10 kg)");
            Console.WriteLine("3. Bulto (hasta 10 kg)");
            Console.WriteLine("4. Bulto (hasta 10 kg)");

            do
            {
                Console.WriteLine("Ingrese su opción: ");

                string ingreso = Console.ReadLine();
                int.TryParse(ingreso, out int TipoServicio);

                if (TipoServicio < 1 || TipoServicio > 4)
                {
                    Console.WriteLine("Ingrese una de las opciones.");
                    continue;
                }


            } while (true);


            do
            {

                Console.WriteLine("Ingrese nombre y apellido del destinatario (sin acentos): ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Es necesario ingresar el nombre y apellido del destinatario.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("El nombre y apellido no debe contener números ni símbolos.");
                    continue;
                }

                NomApDest = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese la dirección del destinatario: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar una dirección.");
                }

                if (ingreso.Length > 80)
                {
                    Console.WriteLine("La dirección no debe exceder los 80 caracteres.");
                }

                bool flag;

                if (flag = hasSpecialChar2(ingreso))
                {
                    Console.WriteLine("La dirección no debe contener símbolos");
                }

                DomDest = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese el código postal del destinatario: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un código postal.");
                }

                if (ingreso.Length > 20)
                {
                    Console.WriteLine("El código postal no debe exceder los 20 caracteres.");
                }

                bool flag;

                if (flag = hasSpecialChar2(ingreso))
                {
                    Console.WriteLine("El código postal no debe contener símbolos");
                }

                CPDest = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese la ciudad del destinatario: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar una ciudad.");
                    continue;
                }


                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("La ciudad no debe contener símbolos ni números");
                    continue;
                }

                if (!Ciudad.Contains(ingreso))
                {
                    Console.WriteLine("La ciudad de destino no se encuentra disponible en este momento.");
                    continue;
                }


                CiuDest = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese la provincia / estado  del destinatario: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar una provincia o un estado.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("La provincia / estado, no debe contener símbolos ni números");
                    continue;
                }

                if (!ProvEst.Contains(ingreso))
                {
                    Console.WriteLine("La provincia / estado no se encuentra disponible en este momento.");
                    continue;
                }


                EstDest = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese el país del destinatario: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un país.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("El país no debe contener símbolos ni números");
                    continue;
                }

                if (!Pais.Contains(ingreso))
                {
                    Console.WriteLine("El país no se encuentra disponible en este momento");
                    continue;
                }

                PaisDest = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese el nombre del remitente: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar el nombre y apellido del remitente.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("El nombre y apellido no debe contener símbolos ni números");
                    continue;
                }

                NomApRem = ingreso;
            } while (true);

            do
            {
                Console.WriteLine("Ingrese la dirección del remitente: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar una dirección.");
                    continue;
                }

                if (ingreso.Length > 80)
                {
                    Console.WriteLine("La dirección no debe exceder los 80 caracteres.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar2(ingreso))
                {
                    Console.WriteLine("La dirección no debe contener símbolos");
                    continue;
                }

                DomRem = ingreso;
            } while (true);

            do
            {
                Console.WriteLine("Ingrese el código postal del remitente: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un código postal.");
                    continue;
                }

                if (ingreso.Length > 20)
                {
                    Console.WriteLine("El código postal no debe exceder los 20 caracteres.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar2(ingreso))
                {
                    Console.WriteLine("El código postal no debe contener símbolos");
                    continue;
                }

                CPRem = ingreso;

            } while (true);

            do
            {
                Console.WriteLine("Ingrese la ciudad del remitente: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar una ciudad.");
                    continue;

                }


                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("La ciudad no debe contener símbolos ni números");
                    continue;
                }

                if (!Ciudad.Contains(ingreso))
                {
                    Console.WriteLine("La ciudad de destino no se encuentra disponible en este momento.");
                }
                CiuRem = ingreso;
            } while (true);

            do
            {
                Console.WriteLine("Ingrese la provincia / estado  del remitente: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar una provincia o un estado.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("La provincia / estado, no debe contener símbolos ni números");
                    continue;
                }

                if (!ProvEst.Contains(ingreso))
                {
                    Console.WriteLine("La provincia / estado no se encuentra disponible en este momento.");
                    continue;
                }
                EstRem = ingreso;



            } while (true);

            do
            {
                Console.WriteLine("Ingrese el país del remitente: ");
                ingreso = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    Console.WriteLine("Debe ingresar un país.");
                    continue;
                }

                bool flag;

                if (flag = hasSpecialChar(ingreso))
                {
                    Console.WriteLine("El país no debe contener símbolos ni números");
                    continue;
                }

                if (!Pais.Contains(ingreso))
                {
                    Console.WriteLine("El país no se encuentra disponible en este momento");
                    continue;
                }
                PaisRem = ingreso;


            } while (true);

            do
            {
                Console.WriteLine($"El envío a destino ¿es entrega en domicilio? De ser así, el valor adicional es de ${PrEnvDom}");
                Console.WriteLine("¿Desea hacer el envío con entrega a domicilio? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S || tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado al domicilio del destinatario.");
                    EntregaPuerta = true;
                }

                if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado a la sucursal");
                    EntregaPuerta = false;
                }


            } while (true);

            do
            {
                Console.WriteLine($"¿El despacho será realizado desde el domicilio del remitente? De ser así, el valor adicional es de ${PrRetDom}");
                Console.WriteLine("¿Desea hacer el despacho desde el domicilio? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S || tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El despacho será realizado desde el domicilio del remitente");
                    RetiroPuerta = true;
                }

                if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El despacho será realizado desde la sucursal");
                    RetiroPuerta = false;
                }
            } while (true);


            do
            {
                Console.WriteLine($"¿Desea que el envío sea realizado de forma urgente? Su valor adicional es de ${PrUrg}");
                Console.WriteLine("¿Desea que el envío sea urgente? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S || tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío será realizado de forma urgente");
                    EnvUrg = true;
                }

                if (tecla.Key == ConsoleKey.N)
                {
                    Console.WriteLine("El envío será realizado de forma normal");
                    EnvUrg = false;
                }

            } while (true);

            Console.WriteLine("El envío será cargado.");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Su precio es: ");
            Console.WriteLine("Precio final (IVA Incluido):  ");
            Console.WriteLine("--------------------------------");

            do
            {
                Console.WriteLine("¿Desea confirmar? Si(S) / No(N)");
                var tecla = Console.ReadKey(intercept: true);

                if (tecla.Key != ConsoleKey.S || tecla.Key != ConsoleKey.N)
                {
                    Console.WriteLine("Ingrese S/N");
                    continue;
                }


                if (tecla.Key == ConsoleKey.S)
                {
                    Console.WriteLine("El envío ha sido cargado");

                }


            } while (true);

            Console.WriteLine("Su código de servicio es: ");
        }

        public static bool hasSpecialChar(string input)
        {
            string specialChar = @"|¡!#$%&/()`^=¿?»«@£§€{}.,;:[]+-~`'°<>_1234567890";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }

        public static bool hasSpecialChar2(string input)
        {
            string specialChar = @"|¡!#$%&/()`^=¿?»«@£§€{}.,;:[]+-~`'°<>_";
            foreach (var item in specialChar)
            {
                if (input.Contains(item)) return true;
            }

            return false;
        }


    }
}

