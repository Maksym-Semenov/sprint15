using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    public class Product
    {
        public enum Category 
        {
            [Display(Name = "Toy")]
            Toy,
            [Display(Name = "Technique")]
            Technique,
            [Display(Name = "Clothes")]
            Clothes,
            [Display(Name = "Transport")]
            Transport
        }

        public int Id { get; set; }
        [Required]
        public Category Type { get; set; }
        [Required]
        public string Name { get; set; }
        [StringLength(1000, MinimumLength = 2)]
        [RegularExpression(@"^(Product.Name)",
         ErrorMessage = "Characters are not allowed.")]
        public string Description { get; set; }
        [Range (0, 100000)]
        public decimal Price { get; set; }
    }
}
