using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeRestaurante.DA
{
    public class DbContexto: DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> opciones) : base(opciones)
        {

        }
        public DbSet<GestorDeRestaurante.Model.Ingredientes> Ingredientes { get; set; }

        public DbSet<GestorDeRestaurante.Model.Medidas>  Medidas { get; set; }

    }
}

