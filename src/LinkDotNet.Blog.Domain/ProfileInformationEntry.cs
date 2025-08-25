using System;
using System.Diagnostics;

namespace LinkDotNet.Blog.Domain;

[DebuggerDisplay("{Content} with sort order {SortOrder}")]
public sealed class ProfileInformationEntry : Entity
{
    public string Content { get; private init; } = default!;

    public int SortOrder { get; set; }

    public string AuthorName { get; private set; } = default!;

    public static ProfileInformationEntry Create(string key, int sortOrder, string? authorName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(key);

        var profileInformationEntry = new ProfileInformationEntry
        {
            Content = key.Trim(),
            SortOrder = sortOrder,
        };

        if (authorName is not null)
        {
            profileInformationEntry.AuthorName = authorName.Trim();
        }

        return profileInformationEntry;
    }
}
