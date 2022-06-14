using COMMON;
using DAL.Entities;
using MVC.UI.Modelss;
using MVC.UI.VMClasses;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.UI.Controllers
{
    public class HomeController : Controller
    {
      
        MovieService movieService = new MovieService();

        public ActionResult index()
        {

            return View(movieService.GetList());
        }

     
        //sepet işlemleri
        [HttpPost]
        public JsonResult AddToCart(CartItem cartItem)
        {
            try
            {
                Movie movie = movieService.GetById(cartItem.Id);
                Cart cart = null;

                if (Session["kcart"] == null)
                {
                    cart = new Cart();
                }
                else
                {
                    cart = Session["kcart"] as Cart;
                }

                CartItem ci = new CartItem();
                ci.Id = movie.Id;
                ci.MovieName = movie.MovieName;
                ci.Price = 50;
                ci.Quantity = cartItem.Quantity;
                ci.MovieDate = cartItem.MovieDate;
                ci.MovieTime = cartItem.MovieTime;

                cart.AddItem(ci);

                Session["kcart"] = cart;

                return Json(movie.Id, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }

        //benim sepetim
        public ActionResult MyCart()
        {
            if (Session["kcart"] != null)
            {
                return View();
            }
            else
            {
                TempData["error"] = "sepetinizde film bulunmamaktadır!";
                return RedirectToAction("Index");
            }
        }

        //sepet silme
        public ActionResult DeleteCartItem(int id)
        {
            Cart cart = Session["kcart"] as Cart;

            if (cart != null)
            {
                cart.DeleteItem(id);
            }

            return RedirectToAction("MyCart");
        }

        public ActionResult CompleteCart()
        {
            Cart cart = Session["kcart"] as Cart;
            //AppUser user = Session["user"] as AppUser;
            AppUser user = Session["member"] as AppUser;


            if (user == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (cart != null)
            {
                string sepetList = "";
                foreach (var item in cart.mycart)
                {
                    Movie movie = movieService.GetById(item.Id);

                    sepetList += $" Film Adı: {item.MovieName} -Toplam Tutar: {item.SubTotal}";
                }

                Random rnd = new Random();
                ViewBag.OrderNumber = rnd.Next(1, 1000);

                //Mail gönderme işlemi yapılamamaktadır. acıklama login controlünde yer almakatadır

                string content = $"Alışveriş Listeniz; Bİletiniz oluşturulmuştur: {ViewBag.OrderNumber} ,filmleriniz:  {sepetList}";
                //MailSender.SendEmail(user.Email, "Sipariş Maili", content);


                Session.Remove("kcart");

            }


            return View();
        }

        public ActionResult Exit()
        {
            Session.Remove("member");
            return RedirectToAction("index");
        }

    }
}