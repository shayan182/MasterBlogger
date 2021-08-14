using System;
using MB.Domain.ArticleCategoryAgg.Exception;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService : IArticleCategoryValidatorService
    {
        private readonly IArticleCategoryRepository _categoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void CheckThisRecordAlreadyExists(string title)
        {
            if (_categoryRepository.Exists(x=>x.Title == title))
                throw new DuplicatedRecordException("This Record Is Exists In Database");
        }
    }
}