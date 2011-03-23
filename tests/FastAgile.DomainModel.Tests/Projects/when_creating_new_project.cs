using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastAgile.DomainModel.Commands;
using FastAgile.DomainModel.Events;
using Ncqrs;
using Ncqrs.Spec;
using Ncqrs.Spec.Fakes;
using Ncqrs.Spec.Xunit;
using Xunit;

namespace FastAgile.DomainModel.Tests.Projects
{
    public class when_creating_new_project : OneEventTestFixture<CreateNewProject, NewProjectCreated>
    {
        private readonly DateTime _now = DateTime.UtcNow;
        private const string ProjectName = "ProjectName";
        private const string ProjectDescription = "ProjectDescription";

        public when_creating_new_project()
        {
            Configuration.Configure();
        }

        protected override void RegisterFakesInConfiguration(EnvironmentConfigurationWrapper configuration)
        {
            var clock = new FrozenClock(_now);
            configuration.Register<IClock>(clock);
        }

        protected override IEnumerable<object> GivenEvents()
        {
            yield return new NewProjectCreated()
            {
                ProjectId = EventSourceId,
                ProjectName = ProjectName,
                ProjectDescription = ProjectDescription,
                CreationDate = _now,
                
               
                
            };
        }

        protected override CreateNewProject WhenExecuting()
        {
            return new CreateNewProject
                       {
                           ProjectId = EventSourceId,
                           Description = ProjectDescription,
                           Name = ProjectName
                       };
        }

        [Fact]
        public void The_project_name_should_have_the_correct_values()
        {
            Assert.Equal(TheEvent.ProjectId, EventSourceId);
            Assert.Equal(TheEvent.ProjectName, ProjectName);
            Assert.Equal(TheEvent.ProjectDescription, ProjectDescription);
        }
    }
}
