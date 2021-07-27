namespace TodoApp.Bll.ViewModels
{
    public class FilterDto : PageDto
    {
        public bool? IsDone { get; set; }

        public string Text { get; set; }
    }
}
