using _01_Framework.Infrastructure;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : BaseRepository<long , ArticleCategory>,IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context): base(context)
        {
            _context = context;
        }

      
    }
}
