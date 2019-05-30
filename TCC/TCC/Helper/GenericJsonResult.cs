using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Helper
{
    public class GenericJsonResult
    {
        public bool OK { get; set; }

        public string Message { get; set; }

        public dynamic DataResponse { get; set; }
    }
}