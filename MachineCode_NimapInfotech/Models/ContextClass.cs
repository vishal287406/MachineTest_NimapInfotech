using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MachineCode_NimapInfotech.Models
{
    public class ContextClass:DbContext
    {
     
        public ContextClass():base("DBCS")
        {
                
        }

        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CategoryModel> Categories{ get; set; }
    }
}