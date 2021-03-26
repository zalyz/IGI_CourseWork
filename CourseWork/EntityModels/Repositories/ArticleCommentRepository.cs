using System.Linq;
using System.Collections.Generic;
using EntityModels.Context;
using EntityModels.Interfaces;
using EntityModels.DamainEntities;
using Microsoft.EntityFrameworkCore;

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
            return _newsContext.ArticleComments.Include(e => e.Author).ToList();
        }

        public void Remove(int id)
        {
            var entity = _newsContext.ArticleComments.First(e => e.Id == id);
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
