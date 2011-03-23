using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataAnnotationsExtensions;
using System.Linq;
using System.Text;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;

namespace FastAgile.DomainModel.Commands
{
    [MapsToAggregateRootConstructor(typeof(DomainObjects.Project))]
    public class CreateNewProject : CommandBase
    {
        [Required]
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
