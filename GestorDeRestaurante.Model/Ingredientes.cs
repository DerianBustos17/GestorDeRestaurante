using System.ComponentModel.DataAnnotations.Schema;

namespace GestorDeRestaurante.Model
{
    public class Ingredientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        [NotMapped]

        public List<Menu>? losPlatillosAsociaados { get; set; }

    }
}