using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class TokenRequest
    {
        [Required]
        [MaxLength(12)]
        public string UserName { get; set; }

        [MaxLength(16)]
        [Required]
        public string Password { get; set; }
    }
}