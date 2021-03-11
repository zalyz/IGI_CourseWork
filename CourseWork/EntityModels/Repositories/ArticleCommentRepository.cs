using System.Linq;
using System.Collections.Generic;
using EntityModels.Context;
using EntityModels.Interfaces;
using EntityModels.DamainEntities;

namespace EntityModels.Repositories
{
    class ArticleCommentRepository : IRepository<ArticleComment>
    {
        private readonly NewsContext _newsContext;

        public ArticleCommentRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public int Add(ArticleComment entity)
        {
            var state = _newsContext.ArticleComments.Add(entity);
            _newsContext.SaveChanges();
            return state.Entity.Id;
        }

        public List<ArticleComment> GetAll()
        {
            return _newsContext.ArticleComments.ToList();
        }

        public void Remove(ArticleComment entity)
        {
            _newsContext.ArticleComments.Remove(entity);
            _newsContext.SaveChanges();
        }

        public void Update(ArticleComment entity)
        {
            _newsContext.ArticleComments.Update(entity);
            _newsContext.SaveChanges();
        }
    }
}
