namespace ScheduleCore.Application.QueryHandlers
{
    public class PageResult<T>
    {
        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int Pagesize { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set; }
        public int TotalResults { get; set; }

        public PageResult(List<T> items, int pageNumber, int pagesize, int totalResults)
        {
            this.Items = items;
            this.PageNumber = pageNumber;
            this.Pagesize = pagesize;
            this.TotalResults = totalResults;

            TotalPages = (int)Math.Ceiling(totalResults / (double)pagesize);
            ItemsFrom = ((PageNumber - 1) * Pagesize) + 1;
            ItemsTo = (ItemsFrom + Pagesize) - 1;

        }
    }
}
