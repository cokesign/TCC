using System.Collections.Generic;

namespace TCC.Helper
{
    public class Menu
    {
        public List<MenuItem> Items { get; set; }
    }

    public class MenuItem
    {
        public string Display { get; set; }
        public object Url { get; set; }
        public bool Active { get; set; }
    }
}