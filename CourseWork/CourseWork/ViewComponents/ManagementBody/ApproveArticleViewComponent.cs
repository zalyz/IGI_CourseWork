using BLL.BusinessInterfaces;
using EntityModels.DamainEntities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CourseWork.Models.SiteManagement;

namespace CourseWork.ViewComponents.ManagementBody
{
    public class ApproveArticleViewComponent : ViewComponent
    {
        private readonly IService<Article> _articleService;

        public ApproveArticleViewComponent(IService<Article> articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var model = new ArticleManagementViewModel
            {
                Articles = _articleService.GetAll().Where(e => e.IsApproved == false).ToList(),
            };
            return View("ApproveArticle", model);
        }
    }
}
