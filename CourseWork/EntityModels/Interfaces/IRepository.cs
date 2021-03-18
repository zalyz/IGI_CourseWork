using System.Collections.Generic;

namespace EntityModels.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        public int Add(T entity);

        public List<T> GetAll();

        public void Update(T entity);

        public void Remove(int id);
    }
}
