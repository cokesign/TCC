using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.ViewModels
{
    public class ApiViewModel
    {

    }

    public class RelatoriosViewModel
    {
        public int IdSensor { get; set; }
        public int IdPlanta { get; set; }
        public decimal Humidade{ get; set; }
        public DateTime HoraLeitura { get; set; }
    }
}