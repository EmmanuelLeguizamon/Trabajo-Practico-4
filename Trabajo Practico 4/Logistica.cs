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
        public int codseguim { get;set;}

        Dictionary<int, int> ClienteyCodSeg = new Dictionary<int, int>();

        //PRIMERO EN EJECTARSE - En caso de que no exista, genera un file con casos forzados. Siempre va a iniciar cargando lo que lea del file en un diccionario.
        public void DatosCoddeSeg() //Extraer del .txt los datos
        {
            //Verifico si el file existe, en caso de no existir se crea.
            if (!File.Exists(@"CodigosdeSeguimiento.txt"))
            {
                using (var sw = new StreamWriter(@"CodigosdeSeguimiento.txt"))
                {
                    //Formato = Cod seguim (KEY), cliente
                    sw.WriteLine("10589,40395");
                    sw.WriteLine("10432,40395");
                    sw.WriteLine("10946,40395");
                    sw.WriteLine("10049,18285");
                    sw.WriteLine("10501,18285");
                    sw.WriteLine("10689,18285");
                    sw.WriteLine("10054,14330");
                    sw.WriteLine("11194,14330");
                    sw.WriteLine("11052,48407");
                    sw.WriteLine("10784,48407");

                    sw.Close();
                }
            }

            using (StreamReader sr = new StreamReader(@"CodigosdeSeguimiento.txt"))
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
                /*foreach (KeyValuePair<int, int> cliente_ in ClienteyCodSeg)
                {
                    Console.WriteLine(cliente_.Key + "\t" + cliente_.Value);
                }*/
            }

        }

        //Genera un nuevo código en base al último generado. Util en clase Servicios.
        public void GeneraryMostrarMostrarCS(int nrocliente)
        {
            //var cliente = new Cliente();
            
            codseguim = codseguim + 1;

            ClienteyCodSeg.Add(codseguim, nrocliente);

            Console.WriteLine($"El  numero de seguimiento es {codseguim} ");
            Console.ReadKey();

            /*
            foreach (KeyValuePair<int, int> cliente__ in ClienteyCodSeg)
            {
                Console.WriteLine(cliente__.Key + "\t" + cliente__.Value);
            }
            Console.ReadKey();
            */
        }

        //ULTIMO EN EJECUTARSE - Genera el file en base a lo que tiene el diccionario. Listo para la próxima ejecución.
        public void GenerarFile()
        {
            using (var sw = new StreamWriter(@"CodigosdeSeguimiento.txt"))
            {
                //Formato = Nro cliente, Cod seguim
                foreach (KeyValuePair<int, int> cliente__ in ClienteyCodSeg)
                {
                    sw.WriteLine(cliente__.Key + "," + cliente__.Value);
                }

                sw.Close();
            }

        }


        public static int ValidarCodigoIngresado()
        {
            bool valido = false;
            int codseg;
            string estado;
            const int MinLenght = 10000;
            const int MaxLenght = 99999;
            var cliente = new Cliente();
            
            
            
            do
            {
                Console.WriteLine("Ingrese el código de seguimiento. (5 dígitos, sin guiones ni espacios)");
                string codigo = Console.ReadLine();
                
                
                
                if (!int.TryParse(codigo, out codseg))
                {
                    Console.WriteLine("\nNo ha ingresado un código de seguimiento válido (5 dígitos, sin guiones ni espacios)" +
                    "\nPresione una tecla para continuar.\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                
                
                
                else if (MinLenght > codseg || codseg > MaxLenght)
                {
                    Console.WriteLine($"\nEl código de seguimiento debe contener 5 dígitos." +
                    "\nPresione una tecla para continuar.\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                
                
                
                else
                {
                    using (StreamReader lector = new StreamReader(@"CodigosdeSeguimiento.txt"))
                    {
                        string line;
                        
                        while ((line = lector.ReadLine()) != null)
                        {
                            string combined = (string.Format(codigo, "," ,cliente.nrocliente));
                            if (line.Contains(combined))
                            {
                                valido = true;
                            }
                        }
                
                        lector.Close();
                    }
                
                    if (!valido)
                    Console.WriteLine("No tenemos ningún servicio registrado con ese número, vuelva a intentarlo");
                }
                
                
                
            } while (valido == false);
                       
            return codseg;
                    
        }
    }
}
