using System.Linq;
using System.Collections.Generic;
using EntityModels.Context;
using EntityModels.Interfaces;
using EntityModels.Users;

namespace EntityModels.Repositories
{
    class AdminRepository : IRepository<Admin>
    {
        private readonly NewsContext _newsContext;

        public AdminRepository(NewsContext newsContext)
        {
            _newsContext = newsContext;
        }

        public int Add(Admin entity)
        {
            var state = _newsContext.Admins.Add(entity);
            _newsContext.SaveChanges();
            return state.Entity.Id;
        }

        public List<Admin> GetAll()
        {
            return _newsContext.Admins.ToList();
        }

        public void Remove(Admin entity)
        {
            _newsContext.Admins.Remove(entity);
            _newsContext.SaveChanges();
        }

        public void Update(Admin entity)
        {
            _newsContext.Update(entity);
            _newsContext.SaveChanges();
        }
    }
}
