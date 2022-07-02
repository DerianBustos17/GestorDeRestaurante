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

        public List<Ingredientes> ObtengaLaListaDeIngredientes()
        {
            var resultado = from c in ElContextoBD.Ingredientes
                            select c;
            return resultado.ToList();
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

        public Medidas ObtenerPorIdLaMedida(int Id)
        {
            Model.Medidas resultado;

            resultado = ElContextoBD.Medidas.Find(Id);

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






        public List<Menu> ObtengaLaListaDePlatillos()
        {
            var resultado = from c in ElContextoBD.Menu
                            select c;
            return resultado.ToList();
        }

        public void AgregueElPlatillo(Menu elPlatillo)
        {
            ElContextoBD.Menu.Add(elPlatillo);
            ElContextoBD.SaveChanges();
        }

        public MenuCompleto ObtengaElMenuCompleto()
        {
            List<Model.Menu> LaListaDePlatillos;
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

        public Menu ObtenerPlatillosPorId(int? Id)
        {
            Model.Menu resultado;

            resultado = ElContextoBD.Menu.Find(Id);

            return resultado;
        }

        public void EditarLosPlatilos(Model.Menu? ElPlatillo)
        {
            Model.Menu ElPlatilloaModificar;

            ElPlatilloaModificar = ObtenerPlatillosPorId(ElPlatillo.Id);

            ElPlatilloaModificar.Nombre = ElPlatillo.Nombre;

            ElPlatilloaModificar.Precio = ElPlatillo.Precio;
            ElPlatilloaModificar.Categoria = ElPlatillo.Categoria;
            ElPlatilloaModificar.Imagen = ElPlatillo.Imagen;

            ElContextoBD.Menu.Update(ElPlatilloaModificar);
            ElContextoBD.SaveChanges();
        }






        public List<MesaOrden> ObtengaLaListaDeOrdenes()
        {
            var resultado = from c in ElContextoBD.MesaOrden
                            select c;
            return resultado.ToList();
        }




        //$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$GERARDO (temporal para no enredarme)#################################################
        public List<Platillos> ObtengaLaListaDelMenuParaIngredientes(List<Menu> losPlatillos, List<MesaOrden> lasOrdenes)
        {
            List<Model.Platillos> elResultado = new List<Model.Platillos>();

            foreach (Model.Menu platillo in losPlatillos)
            {
                Model.Platillos elPlatilloParaIngredientes = new Model.Platillos();

                elPlatilloParaIngredientes.Id = platillo.Id;
                elPlatilloParaIngredientes.Nombre = platillo.Nombre;
                elPlatilloParaIngredientes.Precio = platillo.Precio;

                foreach (Model.MesaOrden orden in lasOrdenes)
                {
                    if (orden.Id_Menu == platillo.Id)
                        elPlatilloParaIngredientes.GananciaAproximada += platillo.Precio * orden.Cantidad;
                }
                elResultado.Add(elPlatilloParaIngredientes);
            }

            return elResultado;
        }

        public List<IngredienteDelPlatillo> ObtengaLaListaDeIngredientesDeUnPlatilloPorId(int id)
        {
            List<Model.IngredienteDelPlatillo> elResultado;

            List<Model.MenuIngredientes> laLista;

            laLista = ObtengaLaListaDeIngredientesDelMenuPorId(id);

            elResultado = ObtengaElResultado(laLista);

            return elResultado;
        }

        private List<IngredienteDelPlatillo> ObtengaElResultado(List<MenuIngredientes> laLista)
        {
            List<Model.IngredienteDelPlatillo> elResultado = new List<Model.IngredienteDelPlatillo>();
            List<Model.Ingredientes> losIngredientes;
            List<Model.Medidas> lasMedidas;

            losIngredientes = ObtengaLaListaDeIngredientes();
            lasMedidas = ObtengaLaListaDeMedidas();

            foreach (MenuIngredientes item in laLista)
            {
                Model.IngredienteDelPlatillo elIngrediente = new Model.IngredienteDelPlatillo();

                elIngrediente.Id = item.Id; 
                elIngrediente.Id_Menu = item.Id_Menu;
                elIngrediente.Id_Ingredientes = item.Id_Ingredientes;
                elIngrediente.Cantidad = item.Cantidad;
                elIngrediente.Id_Medidas = item.Id_Medidas;
                elIngrediente.ValorAproximado = item.ValorAproximado;

                elIngrediente.Nombre = ObtengaElNombreDelIngrediente(losIngredientes, item.Id_Ingredientes);
                elIngrediente.NombreDeLaMedida = ObtengaElNombreDeLaMedida(lasMedidas, item.Id_Medidas);

                elResultado.Add(elIngrediente);
            }

            return elResultado;
            
        }

        private string ObtengaElNombreDeLaMedida(List<Medidas> lasMedidas, int id_Medidas)
        {
            string elResultado = "";

            foreach (var item in lasMedidas)
            {
                if (item.Id == id_Medidas)
                {
                    elResultado = item.Nombre;
                    break;
                }
            }
            return elResultado;
        }

        private string ObtengaElNombreDelIngrediente(List <Model.Ingredientes> losIngredientes, int id_Ingredientes)
        {
            string elResultado = "";

            foreach (var item in losIngredientes)
            {
                if (item.Id == id_Ingredientes)
                {
                    elResultado = item.Nombre;
                    break;
                }
            }
            return elResultado;
        }

        private List<MenuIngredientes> ObtengaLaListaDeIngredientesDelMenuPorId(int id)
        {
            List<MenuIngredientes> elResultado = new List<MenuIngredientes> ();
            List<MenuIngredientes> laListaAuxiliar;

            var laLista = from c in ElContextoBD.MenuIngredientes
                            select c;

            laListaAuxiliar = laLista.ToList();

            foreach (var item in laListaAuxiliar)
            {
                if (item.Id_Menu == id)
                {
                    elResultado.Add(item);
                }
            }

            return elResultado;
        }

        public List<Menu> ObtengaLasEntradas()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas= new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas  = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Entrada")).ToList();
            return LaListaDeEntradas;
        }
        public List<Menu> ObtengaPlatosPrincipales()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas = new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("PlatosPrincipales")).ToList();
            return LaListaDeEntradas;
        }
        public List<Menu> ObtengaLosPostres()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas = new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Postres")).ToList();
            return LaListaDeEntradas;
        }
        public List<Menu> ObtengaLasPequenasBotanas()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas = new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("PequeñasBotanas")).ToList();
            return LaListaDeEntradas;
        }
        public List<Menu> ObtengasLasBebidas()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas = new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Bebidas")).ToList();
            return LaListaDeEntradas;
        }
        public List<Menu> ObtengaLosAperitivos()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas = new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("Aperitivos")).ToList();
            return LaListaDeEntradas;
        }
        public List<Menu> ObtengaLasSopas()
        {
            List<Model.Menu>? LaListaDePlatillos;
            List<Model.Menu>? LaListaDeEntradas = new List<Model.Menu>();
            LaListaDePlatillos = ObtengaLaListaDePlatillos();

            LaListaDeEntradas = LaListaDePlatillos.Where(x => x.Categoria.ToString().Equals("SopasYEnsaladas")).ToList();
            return LaListaDeEntradas;
        }


        public MesasOrdenes ObtengaLasMesasDeOrdenes()
        {
            Model.MesasOrdenes lasMesasDeOrdenes = new Model.MesasOrdenes();

            lasMesasDeOrdenes.MesasNumero1 = ObtengaLasListaDeMesasNumero1();
            lasMesasDeOrdenes.MesasNumero2 = ObtengaLaListaDeMesasNumero2();

            return lasMesasDeOrdenes;
        }

        public List<Mesas> ObtengaLasListaDeMesasNumero1()
        {
            List<Model.Mesas>? LaListaDeMesas;
            List<Model.Mesas>? LalistaDeMesasFiltrada = new List<Model.Mesas>();
            LaListaDeMesas = ObtengaLaListaDeMesas();

            for (int i = 0; i <= (LaListaDeMesas.Count() - 1); i++)
            {
                if (ValideSiMesaEstaAsociadaAUnaOrden(LaListaDeMesas[i].Id) == true)
                {

                    LaListaDeMesas[i].estadoDeLaMesa = EstadoDeLaMesa.Ocupada;
                    LalistaDeMesasFiltrada.Add(LaListaDeMesas[i]);

                }
                else
                {
                    LalistaDeMesasFiltrada.Add(LaListaDeMesas[i]);
                }
                i++;
            }
            return LalistaDeMesasFiltrada;
        }

        public List<Mesas> ObtengaLaListaDeMesasNumero2()
        {
            List<Model.Mesas>? LaListaDeMesas;
            List<Model.Mesas>? LaListaDeMesasFiltradas = new List<Model.Mesas>();
            LaListaDeMesas = ObtengaLaListaDeMesas();

            for (int i = 1; i <= (LaListaDeMesas.Count() - 1); i++)
            {

                if (ValideSiMesaEstaAsociadaAUnaOrden(LaListaDeMesas[i].Id) == true)
                {
                    LaListaDeMesas[i].estadoDeLaMesa = EstadoDeLaMesa.Ocupada;
                    LaListaDeMesasFiltradas.Add(LaListaDeMesas[i]);
                }
                else
                {
                    LaListaDeMesasFiltradas.Add(LaListaDeMesas[i]);
                }
                i++;
            }
            return LaListaDeMesasFiltradas;
        }

        public MesaOrden ObtenerUnaOrden()
        {
            Model.MesaOrden lasMesasDeOrdenes = new Model.MesaOrden();

            lasMesasDeOrdenes.lasMesas = ObtengaLaListaDeMesas();
            lasMesasDeOrdenes.losPlatillos = ObtengaLaListaDePlatillos();
            return lasMesasDeOrdenes;
        }

        public void AgregarUnaOrden(MesaOrden lasOrden)
        {
            lasOrden.Estado = Model.EstadoDeOrdenes.Solicitadas;
            ElContextoBD.MesaOrden.Add(lasOrden);
            ElContextoBD.SaveChanges();
        }

        public Boolean ValideSiMesaEstaAsociadaAUnaOrden(int Id)
        {
            var resultado = from c in ElContextoBD.MesaOrden
                            where c.Id_Mesa == Id
                            select c;
            if (resultado.Count() != 0)
            {
                return true;
            }

            return false;
        }

        public List<int> ObtengaLosIdDePlatillosAsociadosAUnaMensa(int id)
        {

            var resultado = from c in ElContextoBD.MesaOrden
                            where c.Id_Mesa == id
                            select c.Id_Menu;
            return resultado.ToList();
        }

        public List<Menu> ObtengaLosPlatillosAsociadosAUnaMesa(int id)
        {

            var resultado = from c in ElContextoBD.MesaOrden
                            join x in ElContextoBD.Menu on c.Id_Menu equals x.Id
                            where c.Id_Mesa == id
                            select x;
            return resultado.ToList();
        }

        public void CambieEstadoDeOrden(MesaOrden laOrden)
        {
            Model.MesaOrden laOrdenAModificar;

            laOrdenAModificar = ObtengaLaOrden(laOrden);

            laOrdenAModificar.Estado = EstadoDeOrdenes.Servidas;
            ElContextoBD.MesaOrden.Update(laOrdenAModificar);
            ElContextoBD.SaveChanges();
        }

        public MesaOrden ObtengaLaOrden(Model.MesaOrden laOrden)
        {
            Model.MesaOrden laOrdenAModificar;

            var resultado = from c in ElContextoBD.MesaOrden
                            where c.Id_Mesa == laOrden.Id_Mesa && c.Id_Menu == laOrden.Id_Menu
                            select c;
            laOrdenAModificar = ElContextoBD.MesaOrden.Find(resultado.First().Id);
            return laOrdenAModificar;
        }


    }
}