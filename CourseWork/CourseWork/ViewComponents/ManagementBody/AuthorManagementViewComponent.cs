using BLL.BusinessInterfaces;
using EntityModels.Users;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.ViewComponents.ManagementBody
{
    public class AuthorManagementViewComponent : ViewComponent
    {
        private readonly IService<Author> _authorService;

        public AuthorManagementViewComponent(IService<Author> authorService)
        {
            _authorService = authorService;
        }

        public IViewComponentResult Invoke()
        {
            var authors = _authorService.GetAll();
            return View("AuthorManagement", authors);
        }
    }
}
