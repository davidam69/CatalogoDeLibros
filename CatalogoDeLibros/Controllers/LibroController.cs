using Microsoft.AspNetCore.Mvc;
using CatalogoDeLibros.Models;

namespace CatalogoDeLibros.Controllers
{
    public class LibroController : Controller
    {
        private List<Libro> ObtenerLibros()
        {
            var autor1 = new Autor { id = 1, nombre = "George Orwell" };
            var autor2 = new Autor { id = 2, nombre = "Ray Bradbury" };
            return new List<Libro>
            {
                new Libro { id = 1, titulo = "1984", anioPublicacion = 1949, autor = autor1 },
                new Libro { id = 2, titulo = "Fahrenheit 451", anioPublicacion = 1953, autor = autor2 },
                new Libro { id = 3, titulo = "Rebelión en la granja", anioPublicacion = 1945, autor = autor1 }
            };
        }
        public IActionResult Index()
        {
            var libros = ObtenerLibros();
            return View(libros);
        }

        public IActionResult Detalle(int id)
        {
            var libros = ObtenerLibros();
            var libro = libros.FirstOrDefault(l => l.id == id);
            if (libro == null)
            {
                ViewBag.Error = "El libro no fue encontrado.";
                return View("Error");
            }
            return View(libro);
        }
    }
}
