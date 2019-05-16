using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}