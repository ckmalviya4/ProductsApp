using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductsApi.Data
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserNumber { get; set; }

        [Required]
        [MaxLength(12)]      
        public string UserName { get; set; }

        [MaxLength(16)]
        [Required]
        public string Password { get; set; }


        [MaxLength(50)]
        public string FirstName { get; set; }


        [MaxLength(50)]
        public string LastName { get; set; }


        [EmailAddress]
        public string Email { get; set; }

    }
}
