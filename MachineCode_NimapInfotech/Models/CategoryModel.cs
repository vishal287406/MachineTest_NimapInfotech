using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MachineCode_NimapInfotech.Models
{
    [Table("Categories")]
    public class CategoryModel
    {
        [Key]
        public int CategoryId { get; set; }
        
        [Required(ErrorMessage ="*The Category Name Cannot be Empty")]
        [StringLength(25,ErrorMessage ="*Name of Category should not be more than 25 Characters")]
        public string CategoryName { get; set; }
    }
}