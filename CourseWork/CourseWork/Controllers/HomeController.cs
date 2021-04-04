using BLL.BusinessInterfaces;
using CourseWork.Models;
using CourseWork.Models.ArticleModels;
using EntityModels.DamainEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CourseWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly IService<Article> articleServiceservice;
        private readonly IService<Topic> _topicService;

        public HomeController(IService<Article> articleService, IService<Topic> topicService)
        {
            articleServiceservice = articleService;
            _topicService = topicService;
        }

        public IActionResult Index(int? topicId, string title, int page = 1)
        {
            int pageSize = 7;

            //фильтрация
            IEnumerable<Article> articles = null;
            if (!string.IsNullOrEmpty(title))
            {
                articles = articleServiceservice.GetAll().Where(e => e.Title == title && e.IsApproved == true);
            }
            else
            {
                articles = articleServiceservice.GetAll().Where(e => e.IsApproved == true);
            }

            if (topicId != null && topicId != 0)
            {
                articles = articles.Where(e => e.Topic.Id == topicId);
            }

            // пагинация
            var count = articles.Count();
            var items = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // формируем модель представления
            var viewModel = new ArticlesPaginationViewModel
            {
                ArticlePageViewModel = new ArticlePageViewModel(count, page, pageSize),
                ArticleFilterViewModel = new ArticleFilterViewModel(_topicService.GetAll(), topicId, title),
                Articles = articles.ToList(),
            };

            return View(viewModel);
        }

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
