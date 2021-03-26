using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models.AccountModels
{
    public class AccountAuthenticateValidation
    {
        [Required(ErrorMessage = "Enter email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
