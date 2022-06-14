using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.UI.VMClasses
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "kullanıcı zorunlu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "şifre zorunlu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "şifre(tekrar) zorunlu")]
        [Compare("Password", ErrorMessage = "şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "email zorunlu")]
        public string Email { get; set; }

        [Required(ErrorMessage = "isim zorunlu")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Soyisim zorunlu")]
        public string Lastname { get; set; }
    }
}