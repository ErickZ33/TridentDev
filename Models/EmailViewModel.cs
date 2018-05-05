using System.ComponentModel.DataAnnotations;

namespace TridentDev2.Models
{
    public class EmailViewModel : BaseEntity
    {
        [Required]
        [MinLength(2)]
        public string First_Name { get; set; }

        [Required]
        [MinLength(2)]
        public string Last_Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email_Address { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(200)]
        public string Description { get; set; }




    }
}
