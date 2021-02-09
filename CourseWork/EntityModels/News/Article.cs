using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModels.News
{
    class Article
    {
        [Key]
        public int Id { get; set; }

        public byte[] ImageBytes { get; set; }
    }
}
