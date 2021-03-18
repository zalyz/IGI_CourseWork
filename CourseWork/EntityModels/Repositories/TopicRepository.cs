using System.Linq;
using System.Collections.Generic;
using EntityModels.Context;
using EntityModels.Interfaces;
using EntityModels.DamainEntities;

namespace EntityModels.Repositories
{
    class TopicRepository : IRepository<Topic>
    {
        private readonly NewsContext _newsContext;

        public TopicRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public int Add(Topic entity)
        {
            var state = _newsContext.Topics.Add(entity);
            _newsContext.SaveChanges();
            return state.Entity.Id;
        }

        public List<Topic> GetAll()
        {
            return _newsContext.Topics.ToList();
        }

        public void Remove(int id)
        {
            var entity = _newsContext.Topics.First(e => e.Id == id);
            _newsContext.Topics.Remove(entity);
            _newsContext.SaveChanges();
        }

        public void Update(Topic entity)
        {
            _newsContext.Topics.Update(entity);
            _newsContext.SaveChanges();
        }
    }
}
