using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.ViewModels
{
    public class NavBarViewModel
    {
        public List<Menu> Menus { get; set; }
    }

    public class Menu
    {
        public Menu()
        {
            SubMenu = new List<Menu>();
        }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public List<Menu> SubMenu { get; set; }
    }
}