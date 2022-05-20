using System.ComponentModel.DataAnnotations;

namespace CaseAFS.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Email address can not be null "), DataType(DataType.EmailAddress, ErrorMessage = "Email address not in proper format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password can not be null"), DataType(DataType.Password, ErrorMessage = "Password address not in proper format")]
        public string Password { get; set; }
    }
}
