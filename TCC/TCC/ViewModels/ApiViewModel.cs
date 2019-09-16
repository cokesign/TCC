using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.ViewModels
{
    public class ApiViewModel
    {

    }

    public class RelatoriosModel
    {
        public int IdSensor { get; set; }
        public int IdPlanta { get; set; }
        public decimal humidade{ get; set; }
        public DateTime horaLeitura { get; set; }
    }
}