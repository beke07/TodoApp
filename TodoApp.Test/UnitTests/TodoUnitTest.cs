using NUnit.Framework;
using TodoApp.Dal.Entities;

namespace TodoApp.Test
{
    public class TodoUnitTest : TestBase
    {
        [Test]
        public void CreateTest()
        {
            const string OriginalText = "text";

            var todo = new Todo(OriginalText);

            Assert.AreEqual(todo.IsDone, false);
            Assert.AreEqual(todo.Text, OriginalText);
        }

        [Test]
        public void DoneTest()
        {
            var todo = new Todo();

            Assert.AreEqual(todo.IsDone, false);

            todo.Done();

            Assert.AreEqual(todo.IsDone, true);
        }

        [Test]
        public void UpdateTest()
        {
            const string OriginalText = "text";
            const string UpdatedText = "updated-text";

            var todo = new Todo(OriginalText);

            Assert.AreEqual(todo.IsDone, false);
            Assert.AreEqual(todo.Text, OriginalText);

            todo.Update(UpdatedText, true);

            Assert.AreEqual(todo.IsDone, true);
            Assert.AreEqual(todo.Text, UpdatedText);

            todo.Update(null, null);

            Assert.AreEqual(todo.IsDone, true);
            Assert.AreEqual(todo.Text, null);
        }

        [Test]
        public void UpdateWithNullTest()
        {
            const string OriginalText = "text";

            var todo = new Todo(OriginalText);

            Assert.AreEqual(todo.IsDone, false);
            Assert.AreEqual(todo.Text, OriginalText);

            todo.Update(null, null);

            Assert.AreEqual(todo.IsDone, false);
            Assert.AreEqual(todo.Text, null);
        }

        [Test]
        public void DeleteTest()
        {
            const string OriginalText = "text";

            var todo = new Todo(OriginalText);

            todo.Delete();

            Assert.AreEqual(todo.IsDeleted, true);

            todo.Restore();

            Assert.AreEqual(todo.IsDeleted, false);
        }
    }
}