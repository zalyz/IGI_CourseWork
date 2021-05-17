using System.Collections.Generic;
using BLL.BusinessInterfaces;
using EntityModels.DamainEntities;
using EntityModels.Interfaces;

namespace BLL.Services
{
    internal class TopicService : IService<Topic>
    {
        private readonly IRepository<Topic> _topicRepository;

        public TopicService(IRepository<Topic> topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public int Add(Topic entity)
        {
            return _topicRepository.Add(entity);
        }

        public List<Topic> GetAll()
        {
            return _topicRepository.GetAll();
        }

        public void Remove(int id)
        {
            _topicRepository.Remove(id);
        }

        public void Update(Topic entity)
        {
            _topicRepository.Update(entity);
        }
    }
}
