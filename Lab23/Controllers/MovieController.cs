using Lab23.Models;
using Lab23.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab23.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _repository;

        public MovieController(IMovieRepository repository)
        {
            _repository = repository;
        }

        // Here he add the async Task<IActionResult> 
        public async Task<IActionResult> Index()
        {
            var results = await _repository.Get();
            return View(results);
        }

        public IActionResult RegisterMovie()
        {
            return View();
        }

        public async Task<IActionResult> Delete([FromRoute] int id) // you add the atrubute FromRoute
        {
            await _repository.Delete(id);
            return RedirectToAction("Index"); //nameof(Index)
        }

        public async Task<IActionResult> Details([FromRoute] int id) // you add the atrubute FromRoute
        {
            var movie = await _repository.GetById(id);
            return RedirectToAction(nameof(RegisterMovieDetails), movie);
            //await _repository.DeleteAsync(id);
            //return RedirectToAction("Index"); //nameof(Index)
        }

        public async Task<IActionResult> RegisterMovieDetails(MovieViewModel movieModel)
        {
            if (ModelState.IsValid) // Validation properties using atributes asigned to the properties
            {
                await _repository.Create(movieModel);
                return View(movieModel);
            }

            return View("RegisterMovie", movieModel);
        }
    }
}
