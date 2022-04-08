namespace HUIT2022.Pages;

public class Article
{
    public int Id { get; set; }

    public string Title { get; set; }

    public DateTime PostedTime { get; set; }

    public string GetTimeString()
    {
        return PostedTime.ToString("yyyy'年'M'月'd'日'");
    }

    public string Body { get; set; }
}
