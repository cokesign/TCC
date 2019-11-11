using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCC.ViewModels
{
    public class HelperViewModel
    {

    }

    public enum TipoRega
    {
        [Display(Name = "Por Tempo")]
        Timer = 1,
        [Display(Name = "Por Data")]
        Schedule = 2,
        [Display(Name = "Por Jardim")]
        Garden = 3
    }
}