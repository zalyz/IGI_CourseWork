using EntityModels.DamainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Models.ArticleModels
{
    public class ArticlesPaginationViewModel
    {
        public List<Article> Articles { get; set; }

        public ArticlePageViewModel ArticlePageViewModel { get; set; }

        public ArticleFilterViewModel ArticleFilterViewModel { get; set; }
    }
}
