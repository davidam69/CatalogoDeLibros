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
                new Libro { id = 1, titulo = "1984", anioPublicacion = 1949, autor = autor1, UrlImagen = "https://proassetspdlcom.cdnstatics2.com/usuaris/libros/thumbs/b59f709a-ce74-4e50-a3a3-3527d68da121/d_360_620/portada_1984_george-orwell_202102151044.webp" },
                new Libro { id = 2, titulo = "Fahrenheit 451", anioPublicacion = 1953, autor = autor2, UrlImagen ="https://upload.wikimedia.org/wikipedia/en/d/db/Fahrenheit_451_1st_ed_cover.jpg" },
                new Libro { id = 3, titulo = "Rebelión en la granja", anioPublicacion = 1945, autor = autor1, UrlImagen = "https://proassetspdlcom.cdnstatics2.com/usuaris/libros/thumbs/a1ebb647-56f6-4c85-9c2e-a6f9ebb1ef27/d_360_620/portada_rebelion-en-la-granja_george-orwell_202104141022.webp" }
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

        public IActionResult Autor(int id)
        {
            var libros = ObtenerLibros();
            var librosAutor = libros.Where(l => l?.autor?.id == id).ToList();

            if (librosAutor.Count == 0)
            {
                ViewBag.Mensaje = "Este autor no tiene libros registrados.";
                return View("Autor", new List<Libro>());
            }

            return View("Autor", librosAutor);
        }

    }
}
