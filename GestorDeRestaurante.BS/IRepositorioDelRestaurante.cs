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
        void EditarIngredientes(Model.Ingredientes elIngrediente);
        Model.Ingredientes ObtenerIngredientePorId(int Id);




        List<Model.Medidas> ObtengaLaListaDeMedidas();
        Model.Medidas ObTengalaMedida(string Nombre);
        List<Model.Medidas> ObTengaLasMedidasPorNombre(string nombre);
        Model.Medidas ObtenerPorIdLaMedida(int Id);
        void AgregueLaMedida(Model.Medidas medida);
        void EditarLaMedida(Model.Medidas medida);

        List<Model.Mesas> ObtengaLaListaDeMesas();
        void AgregueLasMesas(Model.Mesas lasMesas);
        void EditarLasMesas(Model.Mesas lasMesas);
        Model.Mesas ObtenerMesasPorId(int Id);


        List<Model.Platillos> ObtengaLaListaDePlatillos();
        void AgregueElPlatillo(Model.Platillos elPlatillo);
        Model.MenuCompleto ObtengaElMenuCompleto();
        Model.Platillos ObtenerPlatillosPorId(int? Id);
        void EditarLosPlatilos(Model.Platillos ElPlatillo);

    }
}
