using System.Collections.Generic;

namespace TodoApp.Bll.ViewModels
{
    public class ListViewModel
    {
        public IEnumerable<TodoItemViewModel> List { get; set; }

        public FilterDto Filter { get; set; }
    }
}
