using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastAgile.DomainModel.Events;
using FastAgile.ReadModel;
using FastAgile.ReadModel.Projects;
using Ncqrs.Eventing.ServiceModel.Bus;

namespace FastAgile.ApplicationServices.Denormalizers
{
    public class ProjectDenormalizer : IEventHandler<NewProjectCreated>
    {
        public void Handle(IPublishedEvent<NewProjectCreated> evnt)
        {
            using (var context = new ReadModelContext())
            {
                context.ProjectItems.Add(new ProjectItem
                                             {
                                                 ProjectId = evnt.Payload.ProjectId,
                                                 ProjectName = evnt.Payload.ProjectDescription,
                                                 CreationDate = evnt.Payload.CreationDate
                                             });

                context.SaveChanges();
            }
        }
    }
}
