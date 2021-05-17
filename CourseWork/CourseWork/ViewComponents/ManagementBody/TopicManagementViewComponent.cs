using BLL.BusinessInterfaces;
using CourseWork.Models.SiteManagement;
using EntityModels.DamainEntities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CourseWork.ViewComponents.ManagementBody
{
    public class TopicManagementViewComponent : ViewComponent
    {
        private readonly IService<Topic> _topicService;
        private readonly IService<Article> _articleService;

        public TopicManagementViewComponent(IService<Topic> topicService, IService<Article> articleService)
        {
            _topicService = topicService;
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var approvedArticlesNumber = new List<int>();
            var notApprovedArticlesNumber = new List<int>();
            var amounOfViews = new List<int>();
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

                amounOfViews.Add(_articleService.GetAll()
                    .Where(e => e.Topic.Name == topic.Name && e.IsApproved == true)
                    .Sum(e => e.NumberOfViews)
                    );
            }

            var model = new TopicManagementViewModel
            {
                Topics = _topicService.GetAll(),
                Approved = approvedArticlesNumber,
                NotApproved = notApprovedArticlesNumber,
                AmountOfViews = amounOfViews,
            };
            return View("TopicManagement", model);
        }
    }
}
