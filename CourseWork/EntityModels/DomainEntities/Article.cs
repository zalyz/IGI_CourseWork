using System;
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

        public int NumberOfViews { get; set; }

        public bool IsApproved { get; set; } = false;

        public DateTime Date { get; set; }

        public Topic Topic { get; set; }

        public Author Author { get; set; }
    }
}
