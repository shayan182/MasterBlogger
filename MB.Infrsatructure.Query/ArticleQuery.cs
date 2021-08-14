using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using MB.Domain.CommentAgg;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.Comments)
                .Include(x => x.ArticleCategory)
                .Where(x => x.IsDeleted == false)
                .Select(x =>
                    new ArticleQueryView
                    {
                        Id = x.Id,
                        Title = x.Title,
                        ArticleCategory = x.ArticleCategory.Title,
                        CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                        ShortDescription = x.ShortDescription,
                        Image = x.Image,
                        CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed)
                    })
                .ToList();
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ShortDescription = x.ShortDescription,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ArticleCategory = x.ArticleCategory.Title,
                Content = x.Content,
                CommentsCount = x.Comments.Count(z => z.Status == Statuses.Confirmed),
                Comments = MapComments(x.Comments.Where(x => x.Status == Statuses.Confirmed))
            }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
           return comments
                .Select(comment => new CommentQueryView
                {
                    Name = comment.Name,
                    CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture),
                    Message = comment.Message
                }).ToList();
        }
    }
}