using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CaseAFS.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Email address can not be null ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password can not be null"), DataType(DataType.Password, ErrorMessage = "Password address not in proper format")]
        public string Password { get; set; }

        [NotMapped, Compare("Password", ErrorMessage = "Passwords do not match."), DataType(DataType.Password, ErrorMessage = "Password address not in proper format")]
        public string PasswordRepeat { get; set; }

        [Required(ErrorMessage = "Name can not be null")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Surname can not be null")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Surname can not be null")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Role can not be null")]
        public byte RoleId { get; set; }

        public Role Role { get; set; }

    }
}

