using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Mapping;

namespace MB.Infrastructure.EfCore
{
    public class MasterBloggerContext :DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
           

            base.OnModelCreating(modelBuilder);
        }
    }
}
