using NUnit.Framework;
using StaticPotato;
using StaticPotato.Page;

namespace StaticPotatoTest;

public class Tests
{
    [Test]
    public void ConvertsMarkdownToHtml()
    {
        var page = new Page
        {
            Path = "/some/path",
            Source = "## Test",
            Template = ""
        };
        var fragment = page.ToHtml();
        Assert.That(fragment, Is.EqualTo("<h2>Test</h2>\n"));
    }
    
    [Test]
    public void ExtractsAttributesFromFrontmatter()
    {
        var page = new Page
        {
            Path = "/some/path",
            Source = @"---
title: Home
---
## Test",
            Template = ""
        };
        var attributes = page.Attributes();
        Assert.That(attributes.Title, Is.EqualTo("Home"));
    }
}