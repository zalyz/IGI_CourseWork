using System.Collections.Generic;
using BLL.BusinessInterfaces;
using EntityModels.Interfaces;
using EntityModels.Users;

namespace BLL.Services
{
    class AuthorService : IService<Author>
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public int Add(Author entity)
        {
            return _authorRepository.Add(entity);
        }

        public List<Author> GetAll()
        {
            return _authorRepository.GetAll();
        }

        public void Remove(int id)
        {
            _authorRepository.Remove(id);
        }

        public void Update(Author entity)
        {
            _authorRepository.Update(entity);
        }
    }
}
