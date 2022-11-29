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
    public class ProductDTOUpdate
    {
        [Required]
        public string? name { get; set; }
        public string? description { get; set; }
        public int? agerestriction { get; set; }
        [Required]
        public string? company { get; set; }
        [Required]
        public decimal price { get; set; }
        public IFormFile? image { get; set; }
    }
}
