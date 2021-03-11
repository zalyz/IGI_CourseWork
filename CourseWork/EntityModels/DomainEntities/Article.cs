using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EntityModels.Users;

namespace EntityModels.DamainEntities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public byte[] ImageBytes { get; set; }

        public bool IsApproved { get; set; } = false;

        public Topic Topic { get; set; }

        public Author Author { get; set; }

        public List<ArticleComment> ArticleComments { get; set; }
    }
}
