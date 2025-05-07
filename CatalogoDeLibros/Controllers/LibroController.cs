namespace CatalogoDeLibros.Controllers
{
    public class LibroController : Controller
    {
        private static List<Libro> _libros = new List<Libro>
        {
            new Libro
            {
                id = 1,
                titulo = "1984",
                anioPublicacion = 1949,
                autor = new Autor { id = 1, nombre = "George Orwell" },
                autorId = 1,
                UrlImagen = "https://proassetspdlcom.cdnstatics2.com/usuaris/libros/thumbs/b59f709a-ce74-4e50-a3a3-3527d68da121/d_360_620/portada_1984_george-orwell_202102151044.webp"

            },
            new Libro
            {
                id = 2,
                titulo = "Fahrenheit 451",
                anioPublicacion = 1953,
                autor = new Autor { id = 2, nombre = "Ray Bradbury" },
                autorId = 2,
                UrlImagen = "https://upload.wikimedia.org/wikipedia/en/d/db/Fahrenheit_451_1st_ed_cover.jpg"

            },
            new Libro
            {
                id = 3,
                titulo = "Rebelión en la granja",
                anioPublicacion = 1945,
                autor = new Autor { id = 1, nombre = "George Orwell" },
                autorId = 1,
                UrlImagen = "https://proassetspdlcom.cdnstatics2.com/usuaris/libros/thumbs/a1ebb647-56f6-4c85-9c2e-a6f9ebb1ef27/d_360_620/portada_rebelion-en-la-granja_george-orwell_202104141022.webp"

            }
        };

        private static List<Libro> ObtenerLibros()
        {
            return _libros;
        }


        public IActionResult Index()
        {
            ViewBag.ColorFondo = TempData["ColorFondo"] ?? "white";
            TempData.Keep("ColorFondo"); // mantiene TempData para futuras páginas
            var libros = ObtenerLibros();
            return View(libros);
        }

        public IActionResult Detalle(int id)
        {
            ViewBag.ColorFondo = TempData["ColorFondo"] ?? "white";
            TempData.Keep("ColorFondo"); // mantiene TempData para futuras páginas
            var libros = ObtenerLibros();
            var libro = libros.FirstOrDefault(l => l.id == id);
            if (libro == null)
            {
                ViewBag.Error = "El libro no fue encontrado.";
                return View("Error");
            }

            ViewBag.Mensaje = TempData["Mensaje"];
            return View(libro);
        }

        public IActionResult Autor(int id)
        {
            ViewBag.ColorFondo = TempData["ColorFondo"] ?? "white";
            TempData.Keep("ColorFondo"); // mantiene TempData para futuras páginas
            var libros = ObtenerLibros();
            var librosAutor = libros.Where(l => l?.autor?.id == id).ToList();

            if (librosAutor.Count == 0)
            {
                ViewBag.Mensaje = "Este autor no tiene libros registrados.";
                return View("Autor", new List<Libro>());
            }

            return View("Autor", librosAutor);
        }

        public IActionResult CambiarFondo(string color)
        {
            TempData["ColorFondo"] = color;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Autores = ObtenerAutores(); // método que devuelve lista de autores
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Libro libro)
        {
            ModelState.Remove("autor"); // Ignorar el id al validar
            if (!ModelState.IsValid)
            {
                ViewBag.Autores = ObtenerAutores();
                return View(libro);
            }
            // Simular almacenamiento del libro
            // libros.Add(libro);
            var autorSeleccionado = ObtenerAutores().FirstOrDefault(a => a.id == libro.autorId);
            if (autorSeleccionado == null)
            {
                ModelState.AddModelError("autorId", "El autor no existe.");
                ViewBag.Autores = ObtenerAutores();
                return View(libro);
            }

            libro.autor = autorSeleccionado;
            libro.id = ObtenerLibros().Any()? ObtenerLibros().Max(l => l.id) + 1 : 1; // Asignar un nuevo ID
            ObtenerLibros().Add(libro); // Simular almacenamiento

            TempData["Mensaje"] = $"libro '{libro.titulo}' creado con éxito.";

            return RedirectToAction("Detalle", new { id = libro.id });
        }

        private static List<Autor> ObtenerAutores()
        {
            var autores = new List<Autor>
            {
                new Autor { id = 1, nombre = "George Orwell" },
                new Autor { id = 2, nombre = "Ray Bradbury" }
            };
            return autores;
        }
    }
}
