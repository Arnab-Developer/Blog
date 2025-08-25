using System;

namespace LinkDotNet.Blog.Domain;

public sealed class Skill : Entity
{
    private Skill(string name, string? iconUrl, string capability, ProficiencyLevel proficiencyLevel)
    {
        IconUrl = iconUrl;
        Name = name;
        Capability = capability;
        ProficiencyLevel = proficiencyLevel;
    }

    public string? IconUrl { get; private set; }

    public string Name { get; private set; }

    public string Capability { get; private set; }

    public ProficiencyLevel ProficiencyLevel { get; private set; }

    public string AuthorName { get; private set; } = default!;

    public static Skill Create(string name, string? iconUrl, string capability, string proficiencyLevel, string? authorName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentException.ThrowIfNullOrWhiteSpace(capability);

        var level = ProficiencyLevel.Create(proficiencyLevel);

        iconUrl = string.IsNullOrWhiteSpace(iconUrl) ? null : iconUrl;
        var skill = new Skill(name.Trim(), iconUrl, capability.Trim(), level);

        if (authorName is not null)
        {
            skill.AuthorName = authorName.Trim();
        }

        return skill;
    }

    public void SetProficiencyLevel(ProficiencyLevel level)
    {
        ArgumentNullException.ThrowIfNull(level);
        ProficiencyLevel = level;
    }
}
