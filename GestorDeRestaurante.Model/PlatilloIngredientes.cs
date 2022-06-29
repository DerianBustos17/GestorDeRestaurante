using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.Model
{
    public class PlatilloIngredientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public double Precio { get; set; }

        public double GananciaAproximada { get; set; }
    }
}
