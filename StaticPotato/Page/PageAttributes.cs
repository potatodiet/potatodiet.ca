namespace StaticPotato.Page;

public class PageAttributes
{
    public required string Title { get; set; }
    public DateTime? CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public string? Extended { get; set; }
    public required bool Published { get; set; } = true;
}