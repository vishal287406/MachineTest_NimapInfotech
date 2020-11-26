using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MachineCode_NimapInfotech.Models
{
    public class productViewModel
    {
        public List<ProductModel> listofProducts { get; set; }
        public int TotalRecordsCount { get; set; }
        public int PageNumber { get; set; }

        public int pagesize { get; set; }

    }
}