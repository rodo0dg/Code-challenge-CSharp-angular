using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProductDTOCreate
    {
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? AgeRestriction { get; set; }
        [Required]
        public string? Company { get; set; }
        [Required]
        public decimal Price { get; set; }
        public IFormFile? image { get; set; }
    }
}
