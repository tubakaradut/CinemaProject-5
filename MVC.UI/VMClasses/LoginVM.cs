using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.UI.VMClasses
{
    public class LoginVM
    {
        [Required(ErrorMessage = "kullanıcı zorunlu")]
        public string Username { get; set; }
        [Required(ErrorMessage = "şifre zorunlu")]
        public string Password { get; set; }
    }
}