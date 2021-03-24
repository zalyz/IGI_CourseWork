using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CourseWork.Models
{
    public class ArticleAddValidation
    {
        [Required(ErrorMessage = "Enter topic")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Invalid user name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Choose an image for article")]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage = "Enter an article text.")]
        public string Text { get; set; }

    }
}
