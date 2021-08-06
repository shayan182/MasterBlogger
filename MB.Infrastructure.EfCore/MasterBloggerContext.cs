﻿using Microsoft.EntityFrameworkCore;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Mapping;

namespace MB.Infrastructure.EfCore
{
    public class MasterBloggerContext :DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public MasterBloggerContext(DbContextOptions<MasterBloggerContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
