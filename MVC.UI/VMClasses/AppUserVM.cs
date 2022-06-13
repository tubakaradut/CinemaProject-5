using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.UI.VMClasses
{
    public class AppUserVM
    {
        [Required(ErrorMessage = "Kullanıcı zorunlu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre zorunlu")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre(tekrar) zorunlu")]
        [Compare("Password", ErrorMessage = "şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email zorunlu")]
        public string Email { get; set; }
    }
}