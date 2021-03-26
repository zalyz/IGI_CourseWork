using EntityModels.DamainEntities;
using System.Collections.Generic;

namespace CourseWork.Models.ArticleModels
{
    public class ShowArticleViewModel
    {
        public Article Article { get; set; }

        public List<ArticleComment> ArticleComments { get; set; }
    }
}
