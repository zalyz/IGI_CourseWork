using System.Linq;
using System.Collections.Generic;
using EntityModels.Context;
using EntityModels.Interfaces;
using EntityModels.Users;

namespace EntityModels.Repositories
{
    internal class AuthorRepository : IRepository<Author>
    {
        private readonly NewsContext _newsContext;

        public AuthorRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public int Add(Author entity)
        {
            var state = _newsContext.Authors.Add(entity);
            _newsContext.SaveChanges();
            return state.Entity.Id;
        }

        public List<Author> GetAll()
        {
            return _newsContext.Authors.ToList();
        }

        public void Remove(int id)
        {
            var entity = _newsContext.Authors.First(e => e.Id == id);
            _newsContext.Authors.Remove(entity);
            _newsContext.SaveChanges();
        }

        public void Update(Author entity)
        {
            _newsContext.Authors.Update(entity);
            _newsContext.SaveChanges();
        }
    }
}
