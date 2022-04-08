namespace HUIT2022.Pages;

public class CommentManager
{
    private static readonly HttpClient httpClient = new HttpClient();

    private static Comment[] comments;

    public static async Task<Comment[]> GetComments(int postId)
    {
        string url = $"{Setting.HostAddr}/post/{postId}/comments?limit=10";
        var data = await httpClient.GetFromJsonAsync<GetedComment[]>(url);
        if (data is null) return null;
        comments = data.Select(x => new Comment()
        {
            UserName = x.name,
            CommentBody = x.content,
            CommentId = x.comment_id,
        }).ToArray();
        return comments;
    }

    public static async Task PostComment(int postId, string userName, string commentBody)
    {
        string url = $"{Setting.HostAddr}/post/{postId}/comment";
        var response = await httpClient.PostAsJsonAsync(url, new PostedComment()
        {
            name = userName,
            content = commentBody,
        });
        return;
    }

    public class GetedComment
    {
        public int comment_id { get; set; }

        public string name { get; set; }

        public string content { get; set; }

        public int post_id { get; set; }

        public string timestamp { get; set; }
    }

    public class PostedComment
    {
        public string name { get; set; }

        public string content { get; set; }
    }
}
