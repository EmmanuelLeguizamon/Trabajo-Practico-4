using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Trabajo_Practico_4
{
    class Precios
    {

        private int Cuit = 0;

        public int cuit
        {
            get
            {
                return Cuit;
            }
            set
            {
                Cuit = value;
            }
        }




        public void DatosTarifas()
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
