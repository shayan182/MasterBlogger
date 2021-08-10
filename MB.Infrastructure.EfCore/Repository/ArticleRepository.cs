using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MB.Application.Contracts.ArticleAgg;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleRepository(MasterBloggerContext context)
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
                })
                .ToList();
            
        }

        public void CreateAndSave(Article entity)
        {
            _context.Articles.Add(entity);
            _context.SaveChanges();
        }

        public Article Get(long id)
        {
            return _context.Articles.First(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
