using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastAgile.ReadModel.Projects
{
    public class ProjectItem
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
