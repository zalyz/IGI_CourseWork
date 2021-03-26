using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models.AccountModels
{
    public class AccountRegistrationValidation
    {
        [Required(ErrorMessage = "Enter a nickname")]
        [DataType(DataType.Text)]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "Enter email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
