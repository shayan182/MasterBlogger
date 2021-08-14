using System.Collections.Generic;
using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleAgg;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public List<ArticleViewModel> GetList()
        {
           return _articleRepository.GetList();
        }

        public void Create(CreateArticle command)
        {
            var article = new Article(command.Title, command.ShortDescription, command.Image, command.Content
                , command.ArticleCategoryId);
            _articleRepository.Create(article);
                //
        }

        public void Edit(EditArticle command)
        {
            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title, command.ShortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            //_articleRepository.Save();

        }

        public EditArticle Get(long id)
        {
            var article = _articleRepository.Get(id);
            return new EditArticle
            {
                Title = article.Title,
                Id = article.Id,
                ArticleCategoryId = article.ArticleCategoryId,
                Content = article.Content,
                Image = article.Image,
                ShortDescription = article.ShortDescription
            };

        }

        public void Remove(long id)
        {
            var article = _articleRepository.Get(id);
            article.Remove();
             //_articleRepository.Save();
        }

        public void Activate(long id)
        {
            var article = _articleRepository.Get(id);
            article.Activate();
            //_articleRepository.Save();
        }
    }
}
