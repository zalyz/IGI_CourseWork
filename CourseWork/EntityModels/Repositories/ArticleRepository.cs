using System.Linq;
using System.Collections.Generic;
using EntityModels.Context;
using EntityModels.Interfaces;
using EntityModels.DamainEntities;
using Microsoft.EntityFrameworkCore;

namespace EntityModels.Repositories
{
    class ArticleRepository : IRepository<Article>
    {
        private readonly NewsContext _newsContext;

        public ArticleRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public int Add(Article entity)
        {
            var state = _newsContext.Articles.Add(entity);
            _newsContext.SaveChanges();
            return state.Entity.Id;
        }

        public List<Article> GetAll()
        {
            return _newsContext.Articles.Include(e => e.Author).Include(e => e.Topic).ToList();
        }

        public void Remove(int id)
        {
            var entity = _newsContext.Articles.First(e => e.Id == id);
            _newsContext.Articles.Remove(entity);
            _newsContext.SaveChanges();
        }

        public void Update(Article entity)
        {
            var state = _newsContext.Articles.Update(entity);
            _newsContext.SaveChanges();
        }
    }
}
