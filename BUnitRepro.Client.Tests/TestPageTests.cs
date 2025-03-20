using BUnitRepro.Client.Tests.Components;

namespace BUnitRepro.Client.Tests
{
    public class TestPageTests : Bunit.TestContext
    {
        private readonly IRenderedComponent<TestPage> _page;

        public TestPageTests()
        {
            _page = RenderComponent<TestPage>();
        }

        [Fact]
        public void FindWorkingComponent()
        {
            var component = _page.FindComponents<WorkingComponent>();

            Assert.NotNull(component);
        }

        [Fact]
        public void FindSubComponent()
        {
            var component = _page.FindComponents<SubComponent>();

            Assert.NotNull(component);
        }

        [Fact]
        public void FindBothInInheritanceOrder()
        {
            var subComponent = _page.FindComponents<SubComponent>();
            var topLevelComponent = _page.FindComponents<WorkingComponent>();

            Assert.NotNull(subComponent);
            Assert.NotNull(topLevelComponent);
        }

        [Fact]
        public void FindBothInReverseInheritanceOrder()
        {
            var topLevelComponent = _page.FindComponents<WorkingComponent>();
            // Every search of derived components of WorkingComponent after this point wont be able to cast to derived component
            // same for HasComponent<T>()
            var subComponent = _page.FindComponents<SubComponent>();

            Assert.NotNull(subComponent);
            Assert.NotNull(topLevelComponent);
        }
    }
}
