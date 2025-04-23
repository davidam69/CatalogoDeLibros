namespace CatalogoDeLibros.Models
{
    public class Libro
    {
        public int id { get; set; }
        public string? titulo { get; set; }
        public Autor? autor { get; set; }
        // public string? editorial { get; set; }
        public int anioPublicacion { get; set; }
        // public string? genero { get; set; }
        // public string? sinopsis { get; set; }
        // public string? portada { get; set; }
        // public bool disponible { get; set; } = true;
    }
}
