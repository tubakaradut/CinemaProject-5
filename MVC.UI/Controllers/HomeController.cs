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
        AppUserService _arep=new AppUserService();
        MovieService movieService = new MovieService();


        public ActionResult index()
        {

            return View(movieService.GetList());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUserVM appUserVM)
        {
            AppUser user = _arep.GetDefault(x => x.Username == appUserVM.Username && x.Password == appUserVM.Password).FirstOrDefault();

            if (user.Username != null && user.Password != null)
            {

                if (user.Role == Core.Enum.AppUserRole.Admin)
                {
                    if (!user.IsActive)
                    {
                        return AktifKontrol();
                    }
                    Session["admin"] = user;
                    return RedirectToAction("CategoryList", "Category", new { area = "Admin" });
                }
                else if (user.Role == Core.Enum.AppUserRole.Member)
                {
                    if (!user.IsActive)
                    {
                        return AktifKontrol();
                    }
                    Session["member"] = user;
                    return RedirectToAction("index");
                }

                else
                {
                    TempData["error"] = "kullanıcı bilgileri hatalı!";
                    return View(appUserVM);
                }

            }
            return View(appUserVM);
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.Email = appUserVM.Email;
                appUser.Password = appUserVM.Password;
                appUser.Username = appUserVM.Username;
                appUser.ActivationCode = Guid.NewGuid();
                var result = _arep.Add(appUser);

                TempData["info"] = result;

                //Mailsender
                MailSender.SendEmail(appUserVM.Email, "Üyelik Aktivayon", $"üyeliğinizi aktif hale getirebilmek için linki tıklayın https://localhost:44393/Home/Activation/" + appUser.ActivationCode);
                return RedirectToAction("Pending");


            }
            else
            {
                return View(appUserVM);
            }

        }

        public ActionResult Pending(AppUser user)
        {
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult Activation(Guid id)
        {
            if (id != null)
            {
                AppUser user = _arep.GetDefault(x => x.ActivationCode == id).FirstOrDefault();
                user.IsActive = true;
                _arep.Update(user);
                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("Register");
            }

        }
        private ActionResult AktifKontrol()
        {
            ViewBag.AktifDegil = "Lutfen hesabınızı aktif hale getiriniz...Mailinizi kontrol ediniz...";
            return View("Login");
        }

        //sepet işlemleri
        [HttpPost]
        public JsonResult AddToCart(CartItem cartItem)
        {
            try
            {
                //Movie movie = movieService.GetById(id);
                //Cart cart = null;

                //if (Session["kcart"] == null)
                //{
                //    cart = new Cart();
                //}
                //else
                //{
                //    cart = Session["kcart"] as Cart;
                //}

                //CartItem ci = new CartItem();
                //ci.Id = movie.Id;
                //ci.MovieName = movie.MovieName;
                //ci.Price = 50;

                //cart.AddItem(ci);
                
                //Session["kcart"] = cart;

                return Json(cartItem,JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                //TempData["error"] = $"{id} karşılık gelen ürün bulunamadı";
            }

            return Json(cartItem, JsonRequestBehavior.AllowGet);
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
            AppUser user = Session["user"] as AppUser;

           
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

                


                //Send Mail

                string content = $"Alışveriş Listeniz; Sipariş Numaranız: {ViewBag.OrderNumber} ,filmleriniz:  {sepetList}";
                MailSender.SendEmail(user.Email, "Sipariş Maili", content);


                Session.Remove("kcart");

            }


            return View();
        }


    }
}