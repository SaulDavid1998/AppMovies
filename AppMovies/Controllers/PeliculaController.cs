using AppMovies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMovies.Controllers
{
    public class PeliculaController : Controller
    {

        private MovieContext _movieContext { get; set; }

        public PeliculaController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IActionResult Index()
        {

            var consulta = _movieContext.Pelicula.Include(d => d.Director).Include(e => e.Estudio).ToList();

            return View(consulta);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            var consultaDirectores= _movieContext.Director.OrderBy(d => d.Nombre).ToList();
            ViewBag.Directores = consultaDirectores;

            var consultaEstudios = _movieContext.Estudios.OrderBy(e => e.Nombre).ToList();
            ViewBag.Estudios= consultaEstudios;
            return View();
        }


        [HttpPost]
        public IActionResult Agregar(Pelicula pelicula)
        {

            if (ModelState.IsValid)
            {
                _movieContext.Pelicula.Add(pelicula);
                _movieContext.SaveChanges();
                return RedirectToAction("Index", "Pelicula");
                
            }
            var consultaDirectores = (from d in _movieContext.Director
                                      orderby d.Nombre
                                      select d).ToList();
            ViewBag.Directores = consultaDirectores;

            var consultaEstudios = _movieContext.Estudios.OrderBy(e => e.Nombre).ToList();
            ViewBag.Estudios = consultaEstudios;
            return View(pelicula);

        }

        [HttpGet]
        public IActionResult Editar(int id)
        {

            var consultaDirectores = _movieContext.Director.OrderBy(d => d.Nombre);
            ViewBag.Directores = consultaDirectores;

            var consultaEstudios = _movieContext.Estudios.OrderBy(e => e.Nombre).ToList();
            ViewBag.Estudios = consultaEstudios;
            var consulta = _movieContext.Pelicula.Where(p => p.PeliculaId ==id).FirstOrDefault();
            return View(consulta);
        }


        [HttpPost]
        public IActionResult Editar(Pelicula pelicula)
        {

            if (ModelState.IsValid)
            {
                _movieContext.Pelicula.Update(pelicula);
                _movieContext.SaveChanges();
                return RedirectToAction("Index", "Pelicula");

            }
            var consultaDirectores = (from d in _movieContext.Director
                                      orderby d.Nombre
                                      select d).ToList();
            ViewBag.Directores = consultaDirectores;

            var consultaEstudios = _movieContext.Estudios.OrderBy(e => e.Nombre).ToList();
            ViewBag.Estudios = consultaEstudios;
            return View(pelicula);

        }


        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var consulta= _movieContext.Pelicula.Where(p=>p.PeliculaId==id).FirstOrDefault();

            return View(consulta);
        }


        [HttpPost]
        public IActionResult Eliminar(Pelicula pelicula)
        {
            _movieContext.Pelicula.Remove(pelicula);
            _movieContext.SaveChanges();


            return RedirectToAction("Index", "Pelicula");
        }
    }
}
