using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _bloggerContext;

        public ArticleQuery(MasterBloggerContext bloggerContext)
        {
            _bloggerContext = bloggerContext;
        }

        public List<ArticleQueryView> GetAll()
        {
            return _bloggerContext.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title
            }).ToList();
        }
    }
}