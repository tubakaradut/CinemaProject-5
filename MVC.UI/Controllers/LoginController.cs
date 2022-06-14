using COMMON;
using DAL.Entities;
using MVC.UI.VMClasses;
using Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC.UI.Controllers
{
    public class LoginController : Controller
    {
        //Google, 30 Mayıs 2022 tarihinden itibaren hesabınızın güvende kalmasına yardımcı olmak amacıyla, Google Hesabınızda oturum açmak için yalnızca kullanıcı adı ve şifrenizi isteyen üçüncü taraf uygulamalarının ve cihazların kullanımını artık desteklemeyecektir.Bundan ötürü activasyon kodu ve alışveriş listesi mail olarak atılamadı.kullanıcı aktif/pasif işlemleri de yapılamadı.

        AppUserService appUserService = new AppUserService();
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {

                AppUser appUser = appUserService.GetDefault(x => x.Username == loginVM.Username && x.Password == loginVM.Password /*&& x.IsActive*/).FirstOrDefault();

                if (loginVM != null)
                {
                    //FormsAuthentication.SetAuthCookie(appUser.Username, true);
                    Session["member"] = appUser;
                    return RedirectToAction("CompleteCart", "Home");
                }
                else
                {
                    TempData["error"] = "Kullanıcı Bilgileri Hatalı veya Hesabınızı Aktive Değil!";
                    return View(loginVM);
                }
            }
            else
            {
                return View(loginVM);
            }
        }

        public ActionResult UyeOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeOl(AppUserVM appUserVM)
        {
            if (ModelState.IsValid)
            {
                AppUser getAppUser = appUserService.GetDefault(x => x.Email == appUserVM.Email/* && x.IsActive*/).FirstOrDefault();

                if (getAppUser != null)
                {
                    TempData["error"] = "Aynı mail adresine ait başka bir kayıt bulunmaktadır!";
                    return View(appUserVM);
                }


                AppUser appUser = new AppUser();
                appUser.Email = appUserVM.Email;
                appUser.Password = appUserVM.Password;
                appUser.Username = appUserVM.Username;
                appUser.Firstname = appUserVM.Firstname;
                appUser.Lastname = appUserVM.Lastname;

                //appUser.ActivationCode = Guid.NewGuid();
                var result = appUserService.Add(appUser);

                TempData["info"] = result;

                //Mailsender
                //MailSender.SendEmail(appUserVM.Email, "Üyelik Aktivayon", $"üyeliğinizi aktif hale getirebilmek için linki tıklayın https://localhost:44365/Login/Activation/" + appUser.ActivationCode);

                return RedirectToAction("CompleteCart", "Home");
            }
            else
            {
                return View(appUserVM);
            }

        }
        //public ActionResult Activation(Guid id)
        //{
        //    if (id != null)
        //    {
        //        AppUser user = appUserService.GetDefault(x => x.ActivationCode == id).FirstOrDefault();
        //        user.IsActive = true;
        //        appUserService.Update(user);

        //        Session["user"] = user;

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return RedirectToAction("UyeOl");
        //    }

        //}
    }
}