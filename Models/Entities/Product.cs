using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [Range(0,100)]
        public int? AgeRestriction { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string? Company { get; set; }

        [NotNull]
        [Range(1,1000)]
        public decimal Price { get; set; }
    }
}
