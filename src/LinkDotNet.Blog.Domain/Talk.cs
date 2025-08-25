using System;

namespace LinkDotNet.Blog.Domain;

public sealed class Talk : Entity
{
    public string PresentationTitle { get; private set; } = default!;

    public string Place { get; private set; } = default!;

    public string Description { get; private set; } = default!;

    public DateTime PublishedDate { get; private set; }

    public string AuthorName { get; private set; } = default!;

    public static Talk Create(string presentationTitle, string place, string description, DateTime publishedDate, string? authorName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(presentationTitle);
        ArgumentException.ThrowIfNullOrWhiteSpace(place);
        ArgumentException.ThrowIfNullOrWhiteSpace(description);

        var talk = new Talk
        {
            PresentationTitle = presentationTitle.Trim(),
            PublishedDate = publishedDate,
            Place = place.Trim(),
            Description = description.Trim(),
        };

        if (authorName is not null)
        {
            talk.AuthorName = authorName.Trim();
        }

        return talk;
    }
}
