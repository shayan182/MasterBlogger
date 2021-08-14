using System.Collections.Generic;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.ArticleAgg;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        public List<ArticleViewModel> GetList();


    }
}
