﻿namespace CatalogoDeLibros.Models
{
    public class Libro
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio.")]
        public string? titulo { get; set; }

        [Range(1800, 2025, ErrorMessage = "El año debe estar entre 1800 y 2025.")]
        public int anioPublicacion { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un autor.")]
        public Autor? autor { get; set; }
        public string? UrlImagen { get; set; }
        public int autorId { get; set; }
        // public string? editorial { get; set; }
        // public string? genero { get; set; }
        // public string? sinopsis { get; set; }
        // public bool disponible { get; set; } = true;
    }
}
