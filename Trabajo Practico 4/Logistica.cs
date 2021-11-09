using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    class Logistica
    {
        private int CodSeguim;
        public int codseguim
        {
            get
            {
                return CodSeguim;
            }
            set
            {
                CodSeguim = value;
                
            }
        }
        Dictionary<int, int> ClienteyCodSeg = new Dictionary<int, int>();


        //PRIMERO EN EJECTARSE - En caso de que no exista, genera un file con casos forzados. Siempre va a iniciar cargando lo que lea del file en un diccionario.
        public void DatosCoddeSeg() //Extraer del .txt los datos
        {
            //Verifico si el file existe, en caso de no existir se crea.
            if (!File.Exists(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
            {
                using (var sw = new StreamWriter(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
                {
                    //Formato = Cod seguim (KEY), cliente
                    sw.WriteLine("10001,40395");
                    sw.WriteLine("10002,18285");
                    sw.WriteLine("10003,14330");
                    sw.WriteLine("10004,48407");

                    sw.Close();
                }
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
            {
                string line;
                string[] data;

                while ((line = sr.ReadLine()) != null)
                {
                    data = line.Split(',');
                    int codigdodeseguim = Convert.ToInt32(data[0]);
                    int cliente = Convert.ToInt32(data[1]);

                    ClienteyCodSeg.Add(codigdodeseguim, cliente);
                    codseguim = codigdodeseguim;
                }
                sr.Close();


                // verificación de la tabla
                foreach (KeyValuePair<int, int> cliente_ in ClienteyCodSeg)
                {
                    Console.WriteLine(cliente_.Key + "\t" + cliente_.Value);
                }
            }

        }

        //Genera un nuevo código en base al último generado. Util en clase Servicios.
        public void GeneraryMostrarMostrarCS()
        {
            var cliente_class = new Cliente();

            codseguim = codseguim + 1;

            Console.WriteLine($"El código de seguimiento generado es: {codseguim}");

            ClienteyCodSeg.Add(codseguim, cliente_class.nrocliente);

            foreach (KeyValuePair<int, int> cliente__ in ClienteyCodSeg)
            {
                Console.WriteLine(cliente__.Key + "\t" + cliente__.Value);
            }

        }

        //ULTIMO EN EJECUTARSE - Genera el file en base a lo que tiene el diccionario. Listo para la próxima ejecución.
        public void GenerarFile()
        {
            using (var sw = new StreamWriter(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
            {
                //Formato = Nro cliente, Cod seguim
                foreach (KeyValuePair<int, int> cliente__ in ClienteyCodSeg)
                {
                    sw.WriteLine(cliente__.Key + "," + cliente__.Value);
                }

                sw.Close();
            }

        }


        //en class Logistica (Cyn)

        public static int ValidarCodigoIngresado(string codigo)
        {
            bool valido = false;
            int codseg;
            string estado;
            const int MinLenght = 10000;
            const int MaxLenght = 99999;
            var cliente_class = new Cliente();

            do
            {
                if (!int.TryParse(codigo, out codseg))
                {
                    Console.WriteLine("\nNo ha ingresado un código de seguimiento válido (5 dígitos, sin guiones ni espacios)" +
                        "\nPresione una tecla para continuar.\n");
                    Console.ReadKey();
                    Console.Clear();
                }

                else if (MinLenght > codseg || codseg > MaxLenght)
                {
                    Console.WriteLine($"\nEl número de cliente corporativo debe contener 5 dígitos. " +
                         "\nPresione una tecla para continuar.\n");
                    Console.ReadKey();
                    Console.Clear();
                }

                else
                {
                    using (StreamReader lector = new StreamReader(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
                    {
                        string line;

                        while ((line = lector.ReadLine()) != null)
                        {
                            string combined = (string.Format(codigo, ",", cliente_class.nrocliente));
                            if (line.Contains(combined))
                            {
                                Console.WriteLine("Codigo valido");
                                valido = true;
                            }
                        }

                        lector.Close();
                    }
                }

            } while (valido == false);



            if (codseg % 2 == 0)
            {
                estado = "Recibido: orden de servicio iniciada";

            }else if (codseg % 3 == 0)
            {
                estado = "Recibido: orden de servicio iniciada\n" +
                    "En tránsito: entregado en sucursal";

            }else if (codseg % 5 == 0)
            {
                estado = "Recibido: orden de servicio iniciada\n" +
                    "En tránsito: en centro de distribución";

            }
            else if (codseg % 7 == 0)
            {
                estado = "Recibido: orden de servicio iniciada\n" +
                    "En tránsito: en sucursal para entrega";

            }
            else if (codseg % 11 == 0)
            {
                estado = "Recibido: orden de servicio iniciada\n" + 
                    "En tránsito: en distribución";
            }
            else
            {
                estado = "Recibido: orden de servicio iniciada\n" +
                    "En tránsito: en centro de distribución\n" +
                    "En tránsito: entregado en sucursal\n" +
                    "En tránsito: en sucursal para entrega\n" +
                    "Cerrada: entregado";

            }
            
            return codseg;
            //return estado;
        }
        //Recibido: orden de servicio iniciada
        //En tránsito: entregado en sucursal/retirado, en centro de distribución, en sucursal para entrega, en distribución
        //Cerrada: entregado
        //6: mod 2, mod 3, mod 5, mod 7, mod 11, mod 13

    }
}
