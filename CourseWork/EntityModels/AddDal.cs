using EntityModels.Context;
using EntityModels.DamainEntities;
using EntityModels.Interfaces;
using EntityModels.Repositories;
using EntityModels.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EntityModels
{
    public static class AddDal
    {
        public static void AddDalClasses(this IServiceCollection services)
        {
            services.AddDbContext<NewsContext>(options =>
            {
                options.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=NewsDb;Integrated Security=True");
                options.LogTo(Console.WriteLine);
            });

            services.AddTransient<IRepository<Article>, ArticleRepository>();
            services.AddTransient<IRepository<Topic>, TopicRepository>();
            services.AddTransient<IRepository<ArticleComment>, ArticleCommentRepository>();

            services.AddTransient<IRepository<Author>, AuthorRepository>();
        }
    }
}
