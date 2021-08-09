namespace MB.Application.Contracts.ArticleAgg
{
    public class ArticleViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ArticleCategory { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
    }
}
