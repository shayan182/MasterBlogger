using System.Collections.Generic;
using MB.Application.Contracts.ArticleAgg;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article entity);
    }
}
