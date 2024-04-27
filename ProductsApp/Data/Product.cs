using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Globalization;

namespace ProductsApi.Data
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Unicode(true)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [Unicode(true)]
        public string Description { get; set; }

        public decimal MaxPrice { get; set; } = decimal.Zero;

        public decimal MinPrice { get; set; } = decimal.Zero;

        public DateTime DateLastMaint { get; set; }
    }
}
