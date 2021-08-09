using MB.Application;
using MB.Application.Contracts.ArticleAgg;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;
using MB.Infrastructure.EfCore;
using MB.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MB.Infrastructure.Core
{
    public class Bootstrapper

    {
        public static void Config(IServiceCollection services, string connectionString)
        {
           
            services.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            services.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            services.AddTransient<IArticleApplication, ArticleApplication>();
            services.AddTransient<IArticleRepository, ArticleRepository>();

            services.AddTransient<IArticleCategoryValidatorService, ArticleCategoryValidatorService>();
            services.AddDbContext<MasterBloggerContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
