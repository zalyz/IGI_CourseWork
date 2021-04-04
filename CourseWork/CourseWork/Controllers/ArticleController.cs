using BLL.BusinessInterfaces;
using CourseWork.Models;
using CourseWork.Models.ArticleModels;
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
        private readonly IService<ArticleComment> _articleCommentService;

        public ArticleController(
            IService<Article> articleService,
            IService<Topic> topicService,
            IService<Author> authorService,
            IService<ArticleComment> articleCommentService)
        {
            _articleService = articleService;
            _topicService = topicService;
            _authorService = authorService;
            _articleCommentService = articleCommentService;
        }

        public IActionResult Add()
        {
            var articleViewModel = new ArticleAddViewModel
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
                    Date = DateTime.Now
                };

                _articleService.Add(article);
            }

            return RedirectToAction("Add");
        }

        public IActionResult AddComment(int articleId, string text)
        {
            var comment = new ArticleComment
            {
                ArticleId = articleId,
                AuthorId = int.Parse(User.Claims.First(e => e.Type == "Id").Value),
                DateTime = DateTime.Now,
                Text = text,
            };
            _articleCommentService.Add(comment);

            return RedirectToAction("ShowArticle", new { articleId });
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowArticle(int articleId)
        {
            var showArticleViewModels = new ShowArticleViewModel
            {
                Article = _articleService.GetAll().First(e => e.Id == articleId),
                ArticleComments = _articleCommentService.GetAll().Where(e => e.ArticleId == articleId).ToList(),
            };
            showArticleViewModels.Article.NumberOfViews += 1;
            _articleService.Update(showArticleViewModels.Article);
            return View(showArticleViewModels);
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
