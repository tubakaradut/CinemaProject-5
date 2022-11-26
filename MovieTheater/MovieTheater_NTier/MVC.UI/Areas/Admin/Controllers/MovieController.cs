using DAL.Entities;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Areas.Admin.Controllers
{
    public class MovieController : Controller
    {
        MovieService movieService = new MovieService();
        public ActionResult Index()
        {
            ViewBag.CategoryService = movieService;
            return View(movieService.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
                string result = movieService.Add(movie);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult Update(int id)
        {
            try
            {
                Movie updated = movieService.GetById(id);
                return View(updated);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Movie updated)
        {
            try
            {
                string result = movieService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult Delete(Movie movie)
        {
            try
            {
                Movie deleted = movieService.GetById(movie.Id);
                string result = movieService.RemoveForce(deleted);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }
    }
}