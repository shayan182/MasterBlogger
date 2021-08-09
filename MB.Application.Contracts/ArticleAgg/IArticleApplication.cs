using System.Collections.Generic;

namespace MB.Application.Contracts.ArticleAgg
{
    public interface IArticleApplication
    {
        List<ArticleViewModel> GetList();
    }
}
