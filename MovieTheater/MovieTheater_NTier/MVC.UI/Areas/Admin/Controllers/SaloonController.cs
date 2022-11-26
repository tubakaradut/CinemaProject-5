using DAL.Entities;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Areas.Admin.Controllers
{
    public class SaloonController : Controller
    {
        // GET: Admin/Saloon
        SaloonService saloonService = new SaloonService();

        public ActionResult Index()
        {
            ViewBag.SaloonService = saloonService;
            return View(saloonService.GetList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Saloon saloon)
        {
            try
            {
                string result = saloonService.Add(saloon);
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
                Saloon updated = saloonService.GetById(id);
                return View(updated);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Update(Saloon updated)
        {
            try
            {
                string result = saloonService.Update(updated);
                TempData["info"] = result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return View();
        }

        public ActionResult Delete(Saloon saloon)
        {
            try
            {
                Saloon deleted = saloonService.GetById(saloon.Id);
                string result = saloonService.RemoveForce(deleted);
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