using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HUIT2022.Pages
{
    public class PostModel : PageModel
    {
        public Article Article { get; set; }

        public List<Comment> Comments { get; set; }

        [BindProperty]
        public Comment Comment { get; set; }

        public async Task OnGetAsync(int id)
        {
            Article = await ArticleManager.GetArticle(id.ToString());
            var data = await CommentManager.GetComments(id);
            if (data is null)
            {
                Comments = new();
            }
            else
            {
                Comments = new List<Comment>(data);
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (string.IsNullOrEmpty(Comment.UserName) || string.IsNullOrEmpty(Comment.CommentBody))
            {

            }
            else
            {
                await CommentManager.PostComment(id, Comment.UserName, Comment.CommentBody);
            }

            await OnGetAsync(id);
            return Page();
        }
    }
}
