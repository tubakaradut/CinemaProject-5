using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie

        MovieService movieService = new MovieService();
        SessionService sessionService = new SessionService();
        SaloonService saloonService = new SaloonService();


        public ActionResult Details(int id)
        {
            var sessions = sessionService.GetList();
            var saloons = saloonService.GetList();
            var movie = movieService.GetById(id);
            if (movie != null)
            {
                ViewBag.Sessions = sessions;
                ViewBag.Saloon=saloons;
                return View(movie);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

    }
}