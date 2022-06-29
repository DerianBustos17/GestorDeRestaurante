using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public Categoria Categoria { get; set; }
        public double Precio { get; set; }

        public byte[] Imagen { get; set; }  


    }
}
