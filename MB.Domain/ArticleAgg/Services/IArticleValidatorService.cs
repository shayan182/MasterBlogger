using System.Data;
using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleAgg.Services
{
    public interface IArticleValidatorService
    {
       void CheckThisRecordAlreadyExists(string title);
    }

    
}
