namespace Sandbox.Todo.Application.Tests
{
    using System.Linq;

    using NUnit.Framework;

    using Sandbox.Todo.Application.Interface;

    [TestFixture]
    public class TodoServiceTests
    {
        private ITodoService sut;

        [SetUp]
        public void Setup()
        {
            this.sut = new TodoService(new InMemoryTodoRepository());
        }

        [Test]
        public void AddTodo()
        {
            // Act add
            this.sut.Add("Buy milk");

            // Assert
            var todos = this.sut.GetAll();
            Assert.AreEqual(1, todos.Count);
            Assert.AreEqual("Buy milk", todos.First().Text);
        }

        [Test]
        public void RemoveTodo()
        {
            // Act add
            this.sut.Add("foo");
            this.sut.Add("bar");
            var todoId = this.sut.Add("baz");
            this.sut.Add("qux");

            // Assert add
            var todos = this.sut.GetAll();
            Assert.AreEqual(4, todos.Count);

            // Act remove
            this.sut.Remove(todoId);
            todos = this.sut.GetAll();

            // Assert remove
            Assert.AreEqual(3, todos.Count);
            Assert.IsFalse(todos.Any(t => t.Text == "baz"));
        }

        [Test]
        public void GetAll()
        {
            // Arrange
            this.sut.Add("foo");
            this.sut.Add("bar");
            this.sut.Add("baz");
            this.sut.Add("qux");

            // Act add
            var todos = this.sut.GetAll();

            // Assert
            Assert.AreEqual(4, todos.Count);
            Assert.AreEqual("foo", todos.ElementAt(0).Text);
            Assert.AreEqual("bar", todos.ElementAt(1).Text);
            Assert.AreEqual("baz", todos.ElementAt(2).Text);
            Assert.AreEqual("qux", todos.ElementAt(3).Text);
        }

        [Test]
        public void SetPriority()
        {
            // Arrange
            this.sut.Add("foo");
            var barTodoId = this.sut.Add("bar");
            this.sut.Add("baz");
            var quxTodoId = this.sut.Add("qux");

            // Act add
            this.sut.SetPriority(barTodoId, 1);
            this.sut.SetPriority(quxTodoId, 2);

            // Assert
            var todos = this.sut.GetAll();
            Assert.AreEqual(4, todos.Count);
            Assert.AreEqual("qux", todos.ElementAt(0).Text);
            Assert.AreEqual("bar", todos.ElementAt(1).Text);
            Assert.AreEqual("foo", todos.ElementAt(2).Text);
            Assert.AreEqual("baz", todos.ElementAt(3).Text);
        }
    }
}
