using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;

namespace ProductsApi.Models
{
    public class ProductRequestModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        public decimal MaxPrice { get; set; } = decimal.Zero;

        public decimal MinPrice { get; set; } = decimal.Zero;
    }
}
