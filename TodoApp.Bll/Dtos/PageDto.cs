using System;

namespace TodoApp.Bll.ViewModels
{
    public abstract class PageDto
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; } = 5;

        public int TotalCount { get; set; }

        public void PageDown()
            => PageIndex = 0 < PageIndex ? PageIndex - 1 : 0;

        public void PageUp()
        {
            var maxPageNumberInDouble = TotalCount / (double)PageSize;

            var maxPageNumber = (int)Math.Ceiling(maxPageNumberInDouble) - 1;

            PageIndex = PageIndex < maxPageNumber ? PageIndex + 1 : maxPageNumber;
        }
    }
}