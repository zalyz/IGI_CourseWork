using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models.AccountModels
{
    public class EditProfileViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Description { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
