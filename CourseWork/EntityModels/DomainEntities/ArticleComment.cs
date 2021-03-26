using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityModels.Users;

namespace EntityModels.DamainEntities
{
    public class ArticleComment
    {
        [Key]
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
    }
}
