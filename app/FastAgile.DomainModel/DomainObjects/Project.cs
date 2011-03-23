using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using FastAgile.DomainModel.Events;
using Ncqrs;

namespace FastAgile.DomainModel.DomainObjects
{
    public class Project : Ncqrs.Domain.AggregateRootMappedByConvention
    {
        private string _projectName;
        private string _projectDescription;
        private Backlog _projectBacklog;
        private List<Release> _releases;
        private List<User> _users;
        private DateTime _creationDate;

        public Project(){}

        public Project(Guid projectId, string name, string description)
        {
            Contract.Requires(!String.IsNullOrWhiteSpace(name));
            Contract.Requires(!String.IsNullOrWhiteSpace(description));

            var clock = NcqrsEnvironment.Get<IClock>();

            ApplyEvent(new NewProjectCreated
                           {
                               ProjectId = projectId,
                               ProjectName = name,
                               ProjectDescription = description,
                               CreationDate = clock.UtcNow()
                           });
        }

        private void OnNewProjectCreated(NewProjectCreated evnt)
        {
            _projectName = evnt.ProjectName;
            _projectDescription = evnt.ProjectDescription;
            _creationDate = evnt.CreationDate;
            _projectBacklog = new Backlog();
            _releases = new List<Release>();
            _users = new List<User>();
        }
    }
}
