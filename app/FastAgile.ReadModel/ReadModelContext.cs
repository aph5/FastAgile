using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FastAgile.ReadModel.Projects;

namespace FastAgile.ReadModel
{
    public class ReadModelContext : DbContext
    {
        public DbSet<ProjectItem> ProjectItems { get; set; }
    }
}
