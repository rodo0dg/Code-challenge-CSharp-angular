using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int? ageRestriction { get; set; }
        public string? company { get; set; }
        public decimal price { get; set; }
        public bool hasPicture { get; set; }
        public string? imagePath { get; set; }
        public string? imageMimeType { get; set; }
    }
}
