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


        public ActionResult Details(int id)
        {
            var sessions = sessionService.GetList();
            var movie = movieService.GetById(id);
            if (movie != null)
            {
                ViewBag.Sessions = sessions;
                return View(movie);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        //public PartialViewResult _SampleProducts(Guid id)
        //{
        //    //var products = movieService.GetDefault(x => x.SubCategoryId == id).Take(3).ToList();
        //    //return PartialView(products);
        //}
    }
}