using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging.Abstractions;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public RenameArticleCategory ArticleCategory { get; set; }

        private readonly IArticleCategoryApplication _categoryApplication;

        public EditModel(IArticleCategoryApplication categoryApplication)
        {
            _categoryApplication = categoryApplication;
        }

        public void OnGet(long id)
        {
           ArticleCategory = _categoryApplication.Get(id);
        }

        public RedirectToPageResult OnPost()
        {
            _categoryApplication.Rename(ArticleCategory);
            return RedirectToPage("./List");
        }
    }
}
