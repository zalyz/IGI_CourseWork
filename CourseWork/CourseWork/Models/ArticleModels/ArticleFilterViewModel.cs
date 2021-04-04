using EntityModels.DamainEntities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CourseWork.Models.ArticleModels
{
    public class ArticleFilterViewModel
    {
        public ArticleFilterViewModel(List<Topic> topics, int? topic, string title)
        {
            topics.Insert(0, new Topic { Name = "Все", Id = 0 });
            Topics = new SelectList(topics, "Id", "Name", topic);
            SelectedTopic = topic;
            SelectedTitle = title;
        }
        public SelectList Topics { get; private set; }
        public int? SelectedTopic { get; private set; }
        public string SelectedTitle { get; private set; }
    }
}
