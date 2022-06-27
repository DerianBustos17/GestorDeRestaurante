using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.Model
{
    public class MenuCompleto
    {
        public List<Platillos>? Entradas { get; set; }

        public List<Platillos>? PequeñasBotanas { get; set; }
        public List<Platillos>? Aperitivos { get; set; }
        public List<Platillos>? SopasYEnsaladas { get; set; }
        public List<Platillos>? PlatosPrincipales { get; set; }
        public List<Platillos>? Postres { get; set; }
        public List<Platillos>? Bebidas { get; set; }

    }
}
