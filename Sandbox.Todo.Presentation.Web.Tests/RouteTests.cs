namespace Sandbox.Todo.Presentation.Web.Tests
{
    using NUnit.Framework;

    using Sandbox.Todo.Presentation.Web.Controllers;
    using Sandbox.Todo.Presentation.Web.Plumbing;

    [TestFixture]
    public class RouteTests
    {
        [Test]
        public void ReverseRoute()
        {
            var controller = new Controller(null);
            var sut = new Route(controller);

            var url = sut.ReverseRoute(controller.Index);

            Assert.AreEqual("/contr/index", url);
        }
    }
}
