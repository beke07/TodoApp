namespace TodoApp.Dal.Entities
{
    public partial class Todo
    {
        public Todo()
        { }

        public Todo(string text)
        {
            Text = text;
        }

        public void Done() => IsDone = true;

        public void Update(string text, bool? isDone)
        {
            Text = text;
            IsDone = isDone ?? IsDone;
        }
    }
}
