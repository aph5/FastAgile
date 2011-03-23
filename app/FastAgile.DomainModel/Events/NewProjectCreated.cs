using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastAgile.DomainModel.Events
{
    [Serializable]
    public class NewProjectCreated
    {
         public Guid ProjectId { get; set; }

         public string ProjectName { get; set; }

         public string ProjectDescription { get; set; }

         public DateTime CreationDate { get; set; }
    }
}
