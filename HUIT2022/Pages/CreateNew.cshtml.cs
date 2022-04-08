using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HUIT2022.Pages
{
    public class CreateNewModel : PageModel
    {
        [BindProperty]
        public Article Article { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await ArticleManager.Post(Article.Title, Article.Body);
            return Redirect("/");
        }
    }
}
