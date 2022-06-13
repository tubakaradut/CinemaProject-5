using DAL.Entities;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Areas.Admin.Controllers
{
    public class TheaterController : Controller
    {
        // GET: Admin/Thester

        TheaterService thetaerService = new TheaterService();
        MovieService movieService = new MovieService();
        SessionService sessionService = new SessionService();
        SaloonService saloonService = new SaloonService();
        WeekService weekService = new WeekService();
        public ActionResult Index()
        {
            return View(thetaerService.GetList());
        }

        public ActionResult Create()
        {
            ViewBag.Movie = movieService.GetList();
            ViewBag.Session = sessionService.GetList();
            ViewBag.Saloon = saloonService.GetList();
            ViewBag.Week = weekService.GetList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Theater theater)
        {
            try
            {
                string result = thetaerService.Add(theater);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }
        // güncelleme yapılacak
        public ActionResult Update(int id)
        {
            try
            {
                Theater updated = thetaerService.GetById(id);
                return View(updated);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Theater updated)
        {
            try
            {
                string result = thetaerService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult Delete(Theater theater)
        {
            try
            {
                Theater deleted = thetaerService.GetById(theater.Id);
                string result = thetaerService.RemoveForce(deleted);
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