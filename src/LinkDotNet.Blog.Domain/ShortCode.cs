using System;

namespace LinkDotNet.Blog.Domain;

public class ShortCode : Entity
{
    private ShortCode(string name, string markdownContent)
    {
        Name = name;
        MarkdownContent = markdownContent;
    }

    public string MarkdownContent { get; private set; }

    public string Name { get; set; }

    public string AuthorName { get; private set; } = default!;

    public void Update(string name, string content)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        MarkdownContent = content;
        Name = name;
    }

    public static ShortCode Create(string name, string content, string? authorName = null)
    {
        var shortCode = new ShortCode(name, content);

        if (authorName is not null)
        {
            shortCode.AuthorName = authorName.Trim();
        }

        return shortCode;
    }
}
