using BLL.BusinessInterfaces;
using CourseWork.Models;
using EntityModels.DamainEntities;
using EntityModels.Users;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IService<Article> _articleService;
        private readonly IService<Topic> _topicService;
        private readonly IService<Author> _authorService;

        public ArticleController(
            IService<Article> articleService,
            IService<Topic> topicService,
            IService<Author> authorService)
        {
            _articleService = articleService;
            _topicService = topicService;
            _authorService = authorService;
        }

        public IActionResult Add()
        {
            var articleViewModel = new ArticleViewModel
            {
                Topics = _topicService.GetAll(),
            };

            return View(articleViewModel);
        }

        [HttpGet]
        public IActionResult AddArticle(
            string title,
            string text,
            byte[] img,
            string topicName,
            string userName
            )
        {
            var article = new Article
            {
                Title = title,
                Text = text,
                ImageBytes = img,
                NumberOfViews = 0,
                Topic = _topicService.GetAll().First(e => e.Name == topicName),
                Author = _authorService.GetAll().First(e => e.Name == userName),
            };

            _articleService.Add(article);
            return View();
        }

        [HttpPost]
        public string AddArticle()
        {
            return "Купил";
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
