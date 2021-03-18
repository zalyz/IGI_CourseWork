using BLL.BusinessInterfaces;
using CourseWork.Models.SiteManagement;
using EntityModels.DamainEntities;
using EntityModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var articlePartialView = "ApproveArticleView";

            return View("ManagementBody", GetSiteManagementViewModelWithArticle(articlePartialView));
        }

        public IActionResult ApproveArticle(int id)
        {
            var article = _articleService.GetAll().First(e => e.Id == id);
            article.IsApproved = true;
            _articleService.Update(article);
            return RedirectToAction("GetArticlePartialView");
        }

        public IActionResult GetTopicPartialView()
        {
            var topicPartialView = "TopicManagement";
            return View("ManagementBody", GetSiteManagementViewModelWithTopic(topicPartialView));
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
            return View("ManagementBody");
        }

        private SiteManagementViewModel GetSiteManagementViewModelWithTopic(string partialViewName)
        {
            var approvedArticlesNumber = new List<int>();
            var notApprovedArticlesNumber = new List<int>();
            foreach (Topic topic in _topicService.GetAll())
            {
                approvedArticlesNumber.Add(
                    _articleService.GetAll()
                    .Where(e => e.Topic.Name == topic.Name && e.IsApproved == true)
                    .Count()
                    );

                notApprovedArticlesNumber.Add(
                    _articleService.GetAll()
                    .Where(e => e.Topic.Name == topic.Name && e.IsApproved == false)
                    .Count()
                    );
            }

            return new SiteManagementViewModel
            {
                PartialViewName = partialViewName,
                TopicManagementViewModel = new TopicManagementViewModel
                {
                    Topics = _topicService.GetAll(),
                    Approved = approvedArticlesNumber,
                    NotApproved = notApprovedArticlesNumber,
                },
            };
        }

        private SiteManagementViewModel GetSiteManagementViewModelWithArticle(string partialViewName)
        {
            return new SiteManagementViewModel
            {
                ArticleManagementViewModel = new ArticleManagementViewModel
                {
                    Articles = _articleService.GetAll(),
                },
            };
        }
    }
}
