using EntityModels.DamainEntities;
using System.Collections.Generic;

namespace CourseWork.Models.ArticleModels
{
    public class ArticlesPaginationViewModel
    {
        public List<Article> Articles { get; set; }

        public List<int> CommentsCount { get; set; }

        public ArticlePageViewModel ArticlePageViewModel { get; set; }

        public ArticleFilterViewModel ArticleFilterViewModel { get; set; }
    }
}
