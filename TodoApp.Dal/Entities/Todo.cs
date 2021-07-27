namespace TodoApp.Dal.Entities
{
    public partial class Todo : EntityBase
    {
        public string Text { get; set; }

        public bool IsDone { get; set; }
    }
}
