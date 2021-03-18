using System.Collections.Generic;
using BLL.BusinessInterfaces;
using EntityModels.DamainEntities;
using EntityModels.Interfaces;

namespace BLL.Services
{
    public class ArticleService : IService<Article>
    {
        private readonly IRepository<Article> _articelRepository;

        public ArticleService(IRepository<Article> articelRepository)
        {
            _articelRepository = articelRepository;
        }

        public int Add(Article entity)
        {
            return _articelRepository.Add(entity);
        }

        public List<Article> GetAll()
        {
            return _articelRepository.GetAll();
        }

        public void Remove(int id)
        {
            _articelRepository.Remove(id);
        }

        public void Update(Article entity)
        {
            _articelRepository.Update(entity);
        }
    }
}
