using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.ArticleAgg;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : BaseRepository<long, Article>, IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetList()
        {
            return _context.Articles
                .Include(x=>x.ArticleCategory)
                .Select(x=>new ArticleViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    IsDeleted = x.IsDeleted
                }).OrderByDescending(x=>x.Id)
                .ToList();
            
        }

    }
}
