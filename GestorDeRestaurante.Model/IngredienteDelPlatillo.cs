using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.Model
{
    public class IngredienteDelPlatillo
    {
        public int Id { get; set; }

        public int Id_Menu { get; set; }

        public int Id_Ingredientes { get; set; }

        public double Cantidad { get; set; }

        public int Id_Medidas { get; set; }

        public int ValorAproximado { get; set; }

        public string Nombre { get; set; }

        
        public string NombreDeLaMedida { get; set; }

        
    }
}
