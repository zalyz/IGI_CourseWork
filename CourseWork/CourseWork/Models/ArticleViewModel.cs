﻿using EntityModels.DamainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseWork.Models
{
    public class ArticleViewModel
    {
        public IEnumerable<Topic> Topics { get; set; }
    }
}
