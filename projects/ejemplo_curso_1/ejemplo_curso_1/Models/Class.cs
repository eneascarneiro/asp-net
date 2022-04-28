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
    public class Animal
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }
        public int Edad { get; set; }
    }
    public class Insecto
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public int Edad { get; set; }
    }
    public class Alumno
    {
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;

        public int Edad { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaDeNacimiento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public decimal NotaMedia { get; set; }
    }
}
