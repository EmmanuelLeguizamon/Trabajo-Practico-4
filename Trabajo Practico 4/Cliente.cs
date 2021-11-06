using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    class Cliente
    {

        private int Cuit = 0;

        public int cuit
        {
            get {
                return Cuit;
            }
            set {
                Cuit = value;
            }
        }

        public void Validacion()
        {

            //Validación del tipo de dato númerico. Se almacena si es int
            string input;
            bool valido = false;
            do
            {
                Console.WriteLine("Ingrese su número de cliente corporativo (CUIT)");
                input = Console.ReadLine();

                if (!int.TryParse(input, out int Cuit))
                {
                    Console.WriteLine("No ha ingresado un DNI válido");
                }
                else
                {
                    valido = true;
                }
            } while (valido == false);

            //Validación en archivo del ingreso en el paso anterior
            using (StreamReader sr = new StreamReader("ClientesCorporativos.txt"))
            {
                string line;
                string record;
                line = Cuit.ToString();
                try
                {
                    record = sr.ReadLine();
                    while (record != null)
                    {
                        if (record.Contains(line))
                        {
                            Console.WriteLine("Cliente corporativo válido");
                        }
                    }
                }
                finally
                {
                    record = sr.ReadLine();
                }

                sr.Close();
            }

        }

        public void DatosClientes()
        {
            //Verificao si el file existe, en caso de no existir se crea.
            if (!File.Exists(@"\ClientesCorporativos.txt"))
            {
                using (var writer = new StreamWriter(@"\ClientesCorporativos.txt")) //append: false --> permite sobreescribir
                {
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                    writer.WriteLine("");
                }
            }
        }
    }
}
