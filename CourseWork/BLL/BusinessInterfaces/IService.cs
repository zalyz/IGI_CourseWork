using System.Collections.Generic;

namespace BLL.BusinessInterfaces
{
    public interface IService<T>
        where T : class
    {
        public int Add(T entity);

        public List<T> GetAll();

        public void Update(T entity);

        public void Remove(T entity);
    }
}
