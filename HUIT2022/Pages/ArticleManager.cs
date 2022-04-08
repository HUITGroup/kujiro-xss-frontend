using System.Text;
using System.Text.Json;

namespace HUIT2022.Pages;

public class ArticleManager
{
    private static readonly HttpClient httpClient = new HttpClient();

    public static async Task<Article[]> GetLatests()
    {
        string url = $"{Setting.HostAddr}/post/list?limit=";
        var data = await httpClient.GetFromJsonAsync<GetedArticle[]>(url + "10");
        if (data is null) return null;

        return data.Select(x => new Article()
        {
            Title = x.title,
            Body = x.content,
            Id = (x.post_id),
            PostedTime = DateTime.Parse(x.timestamp)
        }).ToArray();
    }

    public static async Task<Article> GetArticle(string id)
    {
        string url = $"{Setting.HostAddr}/post/";
        var data = await httpClient.GetFromJsonAsync<GetedArticle>(url + id);
        return new Article()
        {
            Title = data.title,
            Body = data.content,
            Id = (data.post_id),
            PostedTime = DateTime.Parse(data.timestamp),
        };
    }

    public static async Task Post(string title, string body)
    {
        string url = $"{Setting.HostAddr}/post";
        var response = await httpClient.PostAsJsonAsync(url, new PostedArticle()
        {
            title = title,
            content = body,
        });
        return;
    }

    public class PostedArticle
    {
        public string title { get; set; }

        public string content { get; set; }
    }

    public class GetedArticle
    {
        public int post_id { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public string timestamp { get; set; }
    }
}