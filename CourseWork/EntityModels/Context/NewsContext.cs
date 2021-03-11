using Microsoft.EntityFrameworkCore;
using EntityModels.DamainEntities;
using EntityModels.Users;

namespace EntityModels.Context
{
    public class NewsContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<ArticleComment> ArticleComments { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Author> Authors { get; set; }

        public NewsContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\sqlexpress;Initial Catalog=NewsDb;Integrated Security=True");
        }
    }
}
