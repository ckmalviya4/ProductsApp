using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;

namespace ProductsApi.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal MaxPrice { get; set; } = decimal.Zero;

        public decimal MinPrice { get; set; } = decimal.Zero;
    }
}
