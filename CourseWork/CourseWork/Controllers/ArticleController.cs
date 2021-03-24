using BLL.BusinessInterfaces;
using CourseWork.Models;
using EntityModels.DamainEntities;
using EntityModels.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpPost]
        public IActionResult AddArticle(ArticleAddValidation articleAddValidation)
        {
            if (ModelState.IsValid)
            {
                var article = new Article
                {
                    Title = articleAddValidation.Title,
                    Text = articleAddValidation.Text,
                    ImageBytes = GetByteArrayFromImage(articleAddValidation.Image),
                    NumberOfViews = 0,
                    Topic = _topicService.GetAll().First(e => e.Name == articleAddValidation.Topic),
                    Author = _authorService.GetAll().First(e => e.Name == articleAddValidation.UserName),
                };

                _articleService.Add(article);
            }

            return RedirectToAction("Add");
        }

        [HttpGet]
        public string AddArticle()
        {
            return "Купил";
        }

        public IActionResult Edit()
        {
            return View();
        }

        private byte[] GetByteArrayFromImage(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }
    }
}
