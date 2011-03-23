using System.Linq;
using Ncqrs.Commanding;
using Xunit;

namespace Ncqrs.Spec.Xunit
{
    public abstract class OneEventTestFixture<TCommand, TEvent>
        : BigBangTestFixture<TCommand>
        where TCommand : ICommand
    {

        public TEvent TheEvent { get; private set; }

        protected override void Finally()
        {
            base.Finally();
            TheEvent = PublishedEvents
                .Select(e => e.Payload)
                .OfType<TEvent>()
                .FirstOrDefault();
        }

        [Fact]
        public void it_should_do_no_more()
        {
            Assert.True(PublishedEvents.Count() == 1);
        }

        [Fact]
        public void the_published_event_is_not_null()
        {
            Assert.NotNull(TheEvent);
        }

        [Fact]
        public void it_should_not_throw()
        {
            Assert.Null(CaughtException);
        }

    }
}
