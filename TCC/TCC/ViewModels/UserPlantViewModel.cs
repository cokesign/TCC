using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.ViewModels
{
    public class UserPlantViewModel
    {
        public JsonObject chartInitial { get; set; }
    }

    public class JsonObject
    {
        public string type { get; set; }
        public Data data { get; set; }
        public dynamic options { get; set; }
    }

    public class Data
    {
        public List<string> labels { get; set; }
        public List<DataSet> datasets { get; set; }
    }

    public class DataSet
    {
        public string label { get; set; }
        public bool fill { get; set; }
        public string borderColor { get; set; }
        public string backgroundColor { get; set; }
        public List<string> data { get; set; }
    }
}