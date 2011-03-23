using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using FastAgile.DomainModel.Events;
using Ncqrs;
using Ncqrs.Eventing.Sourcing.Snapshotting;

namespace FastAgile.DomainModel.DomainObjects
{
    public class Project : Ncqrs.Domain.AggregateRootMappedByConvention, ISnapshotable<ProjectSnapshot>
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

        public ProjectSnapshot CreateSnapshot()
        {
            return new ProjectSnapshot
                       {
                           CreationDate = _creationDate,
                           ProjectBacklog = _projectBacklog,
                           ProjectDescription = _projectDescription,
                           ProjectName = _projectName,
                           Releases = _releases,
                           Users = _users
                       };
        }

        public void RestoreFromSnapshot(ProjectSnapshot snapshot)
        {
            _projectName = snapshot.ProjectName;
            _projectDescription = snapshot.ProjectDescription;
            _projectBacklog = snapshot.ProjectBacklog;
            _releases = snapshot.Releases;
            _users = snapshot.Users;
            _creationDate = snapshot.CreationDate;
        }
    }

    public class ProjectSnapshot
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public Backlog ProjectBacklog { get; set; }
        public List<Release> Releases { get; set; }
        public List<User> Users { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
