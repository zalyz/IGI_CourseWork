using BLL.BusinessInterfaces;
using CourseWork.Models.SiteManagement;
using EntityModels.DamainEntities;
using EntityModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CourseWork.Controllers
{
    public class SiteManagementController : Controller
    {
        private readonly IService<Topic> _topicService;
        private readonly IService<Article> _articleService;
        private readonly IService<Author> _authorService;

        public SiteManagementController(
            IService<Topic> topicService,
            IService<Article> articleService,
            IService<Author> authorService)
        {
            _topicService = topicService;
            _articleService = articleService;
            _authorService = authorService;
        }

        public IActionResult ManagementBody()
        {
            return View(new SiteManagementViewModel());
        }

        public IActionResult GetArticlePartialView()
        {
            var articlePartialView = "ApproveArticle";
            return View("ManagementBody", new SiteManagementViewModel
            {
                PartialViewName = articlePartialView,
            });
        }

        public IActionResult ApproveArticle(int id)
        {
            var article = _articleService.GetAll().First(e => e.Id == id);
            article.IsApproved = true;
            _articleService.Update(article);
            return RedirectToAction("GetArticlePartialView");
        }

        public IActionResult DisapproveArticle(int id)
        {
            _articleService.Remove(id);
            return RedirectToAction("GetArticlePartialView");
        }

        public IActionResult GetTopicPartialView()
        {
            var topicPartialView = "TopicManagement";
            return View("ManagementBody", new SiteManagementViewModel
            {
                PartialViewName = topicPartialView,
            });
        }

        public IActionResult AddTopic(string topicName)
        {
            _topicService.Add(new Topic
            {
                Name = topicName,
            });

            return RedirectToAction("GetTopicPartialView");
        }

        public IActionResult RemoveTopic(int id)
        {
            _topicService.Remove(id);
            return RedirectToAction("GetTopicPartialView");
        }

        public IActionResult GetAuthorPartialView()
        {
            var authorPartialView = "AuthorManagement";
            return View("ManagementBody", new SiteManagementViewModel
            {
                PartialViewName = authorPartialView,
            });
        }

        public IActionResult IncreaceRoleToAuthor(int authorId)
        {
            var author = _authorService.GetAll().First(e => e.Id == authorId);
            switch (author.Role)
            {
                case Role.Author:
                    author.Role = Role.Manager;
                    break;
                case Role.Manager:
                    author.Role = Role.Admin;
                    break;
                case Role.Admin:
                default:
                    break;
            }

            _authorService.Update(author);
            return RedirectToAction("GetAuthorPartialView");
        }

        public IActionResult DecreaceRoleToAuthor(int authorId)
        {
            var author = _authorService.GetAll().First(e => e.Id == authorId);
            switch (author.Role)
            {
                case Role.Manager:
                    author.Role = Role.Author;
                    break;
                case Role.Admin:
                    author.Role = Role.Manager;
                    break;
                case Role.Author:
                default:
                    break;
            }

            _authorService.Update(author);
            return RedirectToAction("GetAuthorPartialView");
        }
    }
}
