using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HUIT2022.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public List<Article> Articles { get; set; }

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public async Task OnGet()
    {
        var data = await ArticleManager.GetLatests();
        if (data is not null)
        {
            Articles = new List<Article>(await ArticleManager.GetLatests());

        }
        else
        {
            Articles = new();
        }
    }
}
