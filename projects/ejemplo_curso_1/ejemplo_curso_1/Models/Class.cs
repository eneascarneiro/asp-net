using System.ComponentModel.DataAnnotations;
namespace ejemplo_curso_1.Models
{
    public class Pelicula
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
    public class Director
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
    }
    public class Actor
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; } = string.Empty;
    }
}
