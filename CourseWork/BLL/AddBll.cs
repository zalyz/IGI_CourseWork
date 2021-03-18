using BLL.BusinessInterfaces;
using BLL.Services;
using EntityModels;
using EntityModels.DamainEntities;
using EntityModels.Users;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class AddBll
    {
        public static void AddBllClassess(this IServiceCollection service)
        {
            service.AddDalClasses();
            service.AddTransient<IService<Article>, ArticleService>();
            service.AddTransient<IService<ArticleComment>, ArticleCommentService>();
            service.AddTransient<IService<Topic>, TopicService>();

            service.AddTransient<IService<Author>, AuthorService>();
        }
    }
}
