using System.Collections.Generic;
using BLL.BusinessInterfaces;
using EntityModels.DamainEntities;
using EntityModels.Interfaces;

namespace BLL.Services
{
    internal class ArticleCommentService : IService<ArticleComment>
    {
        private readonly IRepository<ArticleComment> _articleCommentRepository;

        public ArticleCommentService(IRepository<ArticleComment> articleCommentRepository)
        {
            _articleCommentRepository = articleCommentRepository;
        }

        public int Add(ArticleComment entity)
        {
            return _articleCommentRepository.Add(entity);
        }

        public List<ArticleComment> GetAll()
        {
            return _articleCommentRepository.GetAll();
        }

        public void Remove(int id)
        {
            _articleCommentRepository.Remove(id);
        }

        public void Update(ArticleComment entity)
        {
            _articleCommentRepository.Update(entity);
        }
    }
}
