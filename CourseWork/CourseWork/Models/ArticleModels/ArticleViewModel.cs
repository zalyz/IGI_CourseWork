using EntityModels.DamainEntities;
using System.Collections.Generic;   

namespace CourseWork.Models.ArticleModels
{
    public class ArticleViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }

        public ArticleAddValidation ArticleAddValidation { get; set; }
    }
}
