using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.BS
{
    public interface IRepositorioDelRestaurante
    {
        List<Model.Ingredientes> ObtengaLaListaDeIngredientes();
        void AgregueIngredientes(Model.Ingredientes elIngrediente);
    }
}
