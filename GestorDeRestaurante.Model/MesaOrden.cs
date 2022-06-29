using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.Model
{
    public  class MesaOrden
    {
        public int Id { get; set; }

        public int Id_Mesa { get; set; }

        public int Id_Menu { get; set; }

        public int Cantidad { get; set; }

        public EstadoDeOrdenes Estado { get; set; }
    }
}
