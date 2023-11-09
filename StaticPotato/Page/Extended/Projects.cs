using Scriban;

namespace StaticPotato.Page.Extended;

public class Projects : IExtendedPage
{
    public string Parse(string content)
    {
        var template = Template.Parse(content);
        return template.Render(new { Projects = new Projects() });
    }
}