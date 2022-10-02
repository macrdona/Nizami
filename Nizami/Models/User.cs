using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nizami.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string lastname { get; set; }

        [Required]
        [Phone]
        public string phone_number { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        public string salt { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [MinLength(8)]
        public string password { get; set; }

        //use the expression, for attribute fields not in the users table
        [NotMapped]
        [Required]
        [Compare("password")]
        public string confirm_password { get; set; }

        public string FullName() { return this.firstname + " " + this.lastname; }
    }
}
