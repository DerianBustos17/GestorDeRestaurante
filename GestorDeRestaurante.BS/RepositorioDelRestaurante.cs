using GestorDeRestaurante.Model;

namespace GestorDeRestaurante.BS
{
    public class RepositorioDelRestaurante : IRepositorioDelRestaurante
    {
        private GestorDeRestaurante.DA.DbContexto ElContextoBD;

        public RepositorioDelRestaurante(GestorDeRestaurante.DA.DbContexto contexto)
        {
            ElContextoBD = contexto;
        }

        public void AgregueIngredientes(Ingredientes elIngrediente)
        {
         
            ElContextoBD.Ingredientes.Add(elIngrediente);
            ElContextoBD.SaveChanges();
        }

        public void EditarIngredientes(Ingredientes elIngrediente)
        {
            Model.Ingredientes elIngredienteAModificar;

            elIngredienteAModificar = ObtenerIngredientePorId(elIngrediente.Id);

            elIngredienteAModificar.Nombre = elIngrediente.Nombre;

            ElContextoBD.Ingredientes.Update(elIngredienteAModificar);
            ElContextoBD.SaveChanges();
        }
        public Ingredientes ObtenerIngredientePorId(int Id)
        {
            Model.Ingredientes resultado;

            resultado = ElContextoBD.Ingredientes.Find(Id);

            return resultado;
        }


        public void AgregueLaMedida(Medidas medida)
        {
            ElContextoBD.Medidas.Add(medida);
            ElContextoBD.SaveChanges();
        }

        public void EditarLaMedida(Medidas medida)
        {
            Model.Medidas laMedidaAModificar;

            laMedidaAModificar = ObtenerPorIdLaMedida(medida.Id);

            laMedidaAModificar.Nombre = medida.Nombre;

            ElContextoBD.Medidas.Update(laMedidaAModificar);
            ElContextoBD.SaveChanges();
        }

        public Medidas ObtenerPorIdLaMedida(int Id)
        {
            Model.Medidas resultado;

            resultado = ElContextoBD.Medidas.Find(Id);

            return resultado;
        }

        public List<Ingredientes> ObtengaLaListaDeIngredientes()
        {
            var resultado = from c in ElContextoBD.Ingredientes
                            select c;
            return resultado.ToList();
        }

        public List<Medidas> ObtengaLaListaDeMedidas()
        {
            var resultado = from c in ElContextoBD.Medidas
                            select c;
            return resultado.ToList();
        }

        public Medidas ObTengalaMedida(string Nombre)
        {
            Model.Medidas resultado = null;
            List<Model.Medidas> laLista;

            laLista = ObtengaLaListaDeMedidas();

            foreach (Model.Medidas item in laLista)
            {
                if (item.Nombre == Nombre)
                    resultado = item;
            }

            return resultado;
        }

        public List<Medidas> ObTengaLasMedidasPorNombre(string nombre)
        {
            List<Model.Medidas> laLista;
            List<Model.Medidas> laListaFiltrada;

            laLista = ObtengaLaListaDeMedidas();

            laListaFiltrada = laLista.Where(x => x.Nombre.Contains(nombre)).ToList();
            return laListaFiltrada;
        }

        public List<Mesas> ObtengaLaListaDeMesas()
        {
            var resultado = from c in ElContextoBD.Mesas
                            select c;
            return resultado.ToList();
        }

        public void AgregueLasMesas(Mesas lasMesas)
        {
            lasMesas.Estado = Estado.Disponible;
            ElContextoBD.Mesas.Add(lasMesas);
            ElContextoBD.SaveChanges();
        }

        public void EditarLasMesas(Mesas lasMesas)
        {
            Model.Mesas laMesaAModificar;

            laMesaAModificar = ObtenerMesasPorId(lasMesas.Id);

            laMesaAModificar.Nombre = lasMesas.Nombre;

            laMesaAModificar.Estado = lasMesas.Estado;
            ElContextoBD.Mesas.Update(laMesaAModificar);
            ElContextoBD.SaveChanges();
        }

        public Mesas ObtenerMesasPorId(int Id)
        {
            Model.Mesas resultado;

            resultado = ElContextoBD.Mesas.Find(Id);

            return resultado;
        }


        public List<Platillos> ObtengaLaListaDePlatillos()
        {
            var resultado = from c in ElContextoBD.Menu
                            select c;
            return resultado.ToList();
        }

        public void AgregueElPlatillo(Platillos elPlatillo)
        {
            ElContextoBD.Menu.Add(elPlatillo);
            ElContextoBD.SaveChanges();
        }



        public MenuCompleto ObtengaElMenuCompleto()
        {
            List<Model.Platillos> LaListaDePlatillos;
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            Model.MenuCompleto ElMenuCompleto = new Model.MenuCompleto();

            ElMenuCompleto.Entradas = ObtengaLasEntradas();
            ElMenuCompleto.PlatosPrincipales = ObtengaPlatosPrincipales();
            ElMenuCompleto.Postres = ObtengaLosPostres();
            ElMenuCompleto.PequeñasBotanas = ObtengaLasPequenasBotanas();
            ElMenuCompleto.Aperitivos = ObtengaLosAperitivos();
            ElMenuCompleto.Bebidas = ObtengasLasBebidas();
            ElMenuCompleto.SopasYEnsaladas = ObtengaLasSopas();


            return ElMenuCompleto;
        }
        public List<Platillos> ObtengaLasEntradas()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas= new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas  = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Entrada")).ToList();
            return LaListaDeEntradas;
        }
        public List<Platillos> ObtengaPlatosPrincipales()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas = new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("PlatosPrincipales")).ToList();
            return LaListaDeEntradas;
        }
        public List<Platillos> ObtengaLosPostres()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas = new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Postres")).ToList();
            return LaListaDeEntradas;
        }
        public List<Platillos> ObtengaLasPequenasBotanas()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas = new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("PequeñasBotanas")).ToList();
            return LaListaDeEntradas;
        }
        public List<Platillos> ObtengasLasBebidas()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas = new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Bebidas")).ToList();
            return LaListaDeEntradas;
        }
        public List<Platillos> ObtengaLosAperitivos()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas = new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Aperitivos")).ToList();
            return LaListaDeEntradas;
        }
        public List<Platillos> ObtengaLasSopas()
        {
            List<Model.Platillos>? LaListaDePlatillos;
            List<Model.Platillos>? LaListaDeEntradas = new List<Model.Platillos>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("SopasYEnsaladas")).ToList();
            return LaListaDeEntradas;
        }

        public Platillos ObtenerPlatillosPorId(int? Id)
        {
            Model.Platillos resultado;

            resultado = ElContextoBD.Menu.Find(Id);

            return resultado;
        }

        public void EditarLosPlatilos(Model.Platillos? ElPlatillo)
        {
            Model.Platillos ElPlatilloaModificar;

            ElPlatilloaModificar = ObtenerPlatillosPorId(ElPlatillo.id);

            ElPlatilloaModificar.Nombre = ElPlatillo.Nombre;

            ElPlatilloaModificar.Precio = ElPlatillo.Precio;
            ElPlatilloaModificar.Categoria=ElPlatillo.Categoria;    
            ElPlatilloaModificar.Imagen = ElPlatillo.Imagen;

            ElContextoBD.Menu.Update(ElPlatilloaModificar);
            ElContextoBD.SaveChanges();
        }
    }
}