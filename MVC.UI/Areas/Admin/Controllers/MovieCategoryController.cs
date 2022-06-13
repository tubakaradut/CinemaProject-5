using DAL.Entities;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Areas.Admin.Controllers
{
    public class MovieCategoryController : Controller
    {
        // GET: Admin/MovieCategory

        MovieCategoryService moviecategoryservice = new MovieCategoryService();
        CategoryService categoryService = new CategoryService();
        MovieService movieService = new MovieService();

        public ActionResult Index()
        {
            return View(moviecategoryservice.GetList());
        }

        public ActionResult Create()
        {
            ViewBag.Movie = movieService.GetList();
            ViewBag.Category = categoryService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MovieCategory movieCategory)
        {
            try
            {
                string result = moviecategoryservice.Add(movieCategory);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }
       //güncelleme yapılacak
        public ActionResult Update(int id)
        {
            try
            {
                ViewBag.Movie = movieService.GetList();
                ViewBag.Category = categoryService.GetList();
                MovieCategory updated = moviecategoryservice.GetById(id);
                return View(updated);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(MovieCategory updated)
        {
            try
            {
                string result = moviecategoryservice.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult Delete(MovieCategory movieCategory)
        {
            try
            {
                MovieCategory deleted = moviecategoryservice.GetById(movieCategory.Id);
                string result = moviecategoryservice.RemoveForce(deleted);
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