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

        private int CodSeguim = 10000;

        public int codseguim
        {
            get
            {
                return CodSeguim;
            }
            set
            {
                if (value == 1) 
                {
                    CodSeguim = CodSeguim + 1;
                }
                else if (value != 1)
                {
                    codseguim = value;
                }
            }
        }

        public void MostrarCodigoGenerado( )
        {
            var cliente__class = new Cliente();

            using (StreamReader sr = new StreamReader(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
            {
                string line;
                string[] data;
                Dictionary<int, int> ClienteyCodSeg = new Dictionary<int, int>();

                while ((line = sr.ReadLine()) != null)
                {
                    //data = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    data = line.Split(',');
                    int cliente = Convert.ToInt32(data[0]);
                    int codigdodeseguim = Convert.ToInt32(data[1]);

                    //string combined = (string.Format("{0}\t{1}\n", cliente, codigdodeseguim));

                    ClienteyCodSeg.Add(cliente, codigdodeseguim);
                }
                sr.Close();

                //string combined = (string.Format("{0}\t{1}\n", cliente.nrocliente, codseguim));

                ClienteyCodSeg.Add(cliente__class.nrocliente, codseguim);

                Console.WriteLine($"El código de seguimiento generado es: {codseguim}");

                foreach (KeyValuePair<int, int> cliente__ in ClienteyCodSeg)
                {
                    Console.WriteLine(cliente__.Key + "\t" + cliente__.Value);
                }
            }
        }

        public void AsociarCodSeg()
        {

        }


        public void ConsultarCodSeg()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
            {
                string line;
                string[] data;
                Dictionary<int,int> ClienteyCodSeg = new Dictionary<int,int>();

                while ((line = sr.ReadLine()) != null)
                {
                    //data = str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    data = line.Split(',');
                    int cliente = Convert.ToInt32(data[0]);
                    int codigdodeseguim = Convert.ToInt32(data[1]);
                    
                    //string combined = (string.Format("{0}\t{1}\n", cliente, codigdodeseguim));

                    ClienteyCodSeg.Add(cliente,codigdodeseguim);
                }
                sr.Close();

                foreach (KeyValuePair<int, int> cliente__ in ClienteyCodSeg)
                {
                    Console.WriteLine(cliente__.Key + "\t" + cliente__.Value);
                }
            }
        }

        public void DatosCodigosdeSeg()
        {
            //Verificao si el file existe, en caso de no existir se crea.
            if (!File.Exists(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
            {
                using (var writer = new StreamWriter(@"C:\Users\Melu\Source\Repos\Trabajo-Practico-4\CodigosdeSeguimiento.txt"))
                {
                    //Formato = Nro cliente, Cod seguim
                    writer.WriteLine("40395,10001");
                    writer.WriteLine("18285,10002");
                    writer.WriteLine("14330,10003");
                    writer.WriteLine("48407,10004");

                    writer.Close();
                }
            }
        }

        //en class Logistica

        public static int ValidarCodigo(string codigo)
        {
            bool valido = false;
            int codseg;
            const int MinLenght = 10000;
            const int MaxLenght = 99999;

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
                    using (StreamReader lector = new StreamReader(@"SolicitudesDeServicio.txt"))
                    {
                        string line;

                        while ((line = lector.ReadLine()) != null)
                        {
                            if (line.Contains(codigo))
                            {
                                valido = true;
                            }
                        }

                        lector.Close();
                    }
                }

            } while (valido == false);

            return codseg;
        }


    }
}
