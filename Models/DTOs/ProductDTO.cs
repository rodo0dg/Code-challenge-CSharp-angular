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
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? AgeRestriction { get; set; }
        public string? Company { get; set; }
        public decimal Price { get; set; }
        public bool HasPicture { get; set; }
        public string? imagePath { get; set; }
        public string? imageMimeType { get; set; }
    }
}
