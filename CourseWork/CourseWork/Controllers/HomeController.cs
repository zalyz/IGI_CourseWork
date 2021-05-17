using BLL.BusinessInterfaces;
using CourseWork.Models;
using CourseWork.Models.ArticleModels;
using EntityModels.DamainEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CourseWork.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IService<Article> _articleServices;
        private readonly IService<ArticleComment> _articleCommentService;
        private readonly IService<Topic> _topicService;

        public HomeController(IService<Article> articleService, IService<ArticleComment> articleCommentService, IService<Topic> topicService)
        {
            _articleServices = articleService;
            _articleCommentService = articleCommentService;
            _topicService = topicService;
        }

        //[Authorize(Roles = "Author")]
        public IActionResult Index(int? topicId, string title, int page = 1)
        {
            int pageSize = 5;

            //фильтрация
            IEnumerable<Article> articles = null;
            if (!string.IsNullOrEmpty(title))
            {
                articles = _articleServices.GetAll().Where(e => e.Title.Contains(title) && e.IsApproved == true);
            }
            else
            {
                articles = _articleServices.GetAll().Where(e => e.IsApproved == true);
            }

            if (topicId != null && topicId != 0)
            {
                articles = articles.Where(e => e.Topic.Id == topicId);
            }

            // пагинация
            var count = articles.Count();
            var items = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var commentsNumber = new List<int>();
            foreach (var item in items)
            {
                commentsNumber.Add(
                    _articleCommentService.GetAll().Count(e => e.ArticleId == item.Id));
            }

            // формируем модель представления
            var viewModel = new ArticlesPaginationViewModel
            {
                ArticlePageViewModel = new ArticlePageViewModel(count, page, pageSize),
                ArticleFilterViewModel = new ArticleFilterViewModel(_topicService.GetAll(), topicId, title),
                Articles = items.ToList(),
                CommentsCount = commentsNumber,
            };

            return View(viewModel);
        }

        //[Authorize(Roles = "Manager")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
