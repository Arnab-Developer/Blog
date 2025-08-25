using LinkDotNet.Blog.Domain;

namespace LinkDotNet.Blog.TestUtilities;

public class ProfileInformationEntryBuilder
{
    private string content = "Content";
    private int sortOrder;
    private string authorName = "";

    public ProfileInformationEntryBuilder WithContent(string key)
    {
        content = key;
        return this;
    }

    public ProfileInformationEntryBuilder WithSortOrder(int sortOrder)
    {
        this.sortOrder = sortOrder;
        return this;
    }

    public ProfileInformationEntryBuilder WithAuthorName(string authorName)
    {
        this.authorName = authorName;
        return this;
    }

    public ProfileInformationEntry Build()
    {
        return ProfileInformationEntry.Create(content, sortOrder, authorName);
    }
}
