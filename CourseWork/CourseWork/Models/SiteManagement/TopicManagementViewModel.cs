using EntityModels.DamainEntities;
using System.Collections.Generic;

namespace CourseWork.Models.SiteManagement
{
    public class TopicManagementViewModel
    {
        public List<Topic> Topics { get; set; }

        public List<int> Approved { get; set; }

        public List<int> NotApproved { get; set; }

        public List<int> AmountOfViews { get; set; }
    }
}
