using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MachineCode_NimapInfotech.Models
{
    [Table("Products")]
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "*The Product Name Cannot be Empty")]
        [StringLength(25, ErrorMessage = "*Name of Product should not be more than 25 Characters")]
        public string ProductName { get; set; }

        public int CategoryId { get; set; }

        public CategoryModel Category { get; set; }
    }
}