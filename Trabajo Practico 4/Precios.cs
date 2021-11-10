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

        private string Tipo = "";

        public string tipo
        {
            get
            {
                return Tipo;
            }
            set
            {
                Tipo = value;
            }
        }
        //servicio 1 sobre o 2 hasta 10kg o 3 hasta 20kg o 4 hasta 30kg
        //tipo de entrga 1 a domicilio o 2 en sucursal
        //tipo de retiro 1 en puerta o 2 en sucursal
        //destino 1 Local (nacional) o 2 porvincial(misma prov) o 3 regional (misma region) o 4 nacional(inter-regional) o
        //5 internacional (paises lim) o 6 Internacional (resto am lat) o 7 Inter (amer norte) o 8 Inter (Europa) o 9 Inter (asia)
        //Internacional es facturar CABA + Internacional 

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
