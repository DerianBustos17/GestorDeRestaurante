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
<<<<<<< HEAD
        void EditarIngredientes(Model.Ingredientes elIngrediente);
        Model.Ingredientes ObtenerIngredientePorId(int Id);
=======



        List<Model.Medidas> ObtengaLaListaDeMedidas();
        Model.Medidas ObTengalaMedida(string Nombre);
        List<Model.Medidas> ObTengaLasMedidasPorNombre(string nombre);
        Model.Medidas ObtenerPorIdLaMedida(int Id);
        void AgregueLaMedida(Model.Medidas medida);
        void EditarLaMedida(Model.Medidas medida);
>>>>>>> fbb02e1d268bbf558658fb6d4efc0b2bba5d1584
    }
}
