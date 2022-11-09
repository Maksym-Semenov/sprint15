using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductsValidation.Models
{
    [DescriptionAttribute]
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

        [MinLength(2, ErrorMessage ="Length of name must be 2 or more symbols")]
        public string Description { get; set; }

        [Range (0, 100000)]
        public decimal Price { get; set; }

        public class DescriptionAttribute : ValidationAttribute
        {
            public DescriptionAttribute()
            {
                ErrorMessage = "Description must be started with product's name";
            }
            public override bool IsValid(object value)
            {
                if (value is Product product)
                {
                    if (product.Description.StartsWith(product.Name, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
