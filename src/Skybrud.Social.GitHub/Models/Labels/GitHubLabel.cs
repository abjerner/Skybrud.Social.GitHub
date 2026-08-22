using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Labels;

/// <summary>
/// Class representing a GitHub label.
/// </summary>
public class GitHubLabel : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the label.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the label.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets the API URL of the label.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the name of the label.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the description of the label.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets whether the label has a description.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Description))]
    public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

    /// <summary>
    /// Gets the color of the label.
    /// </summary>
    public string Color { get; }

    /// <summary>
    /// Gets this is a default label.
    /// </summary>
    public bool IsDefault { get; }

    #endregion

    #region Constructors

    private GitHubLabel(JObject json) : base(json) {
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        Url = json.GetRequiredString("url");
        Name = json.GetRequiredString("name");
        Description = json.GetString("description");
        Color = json.GetRequiredString("color");
        IsDefault = json.GetBoolean("default");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubLabel"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubLabel"/>.</returns>
    public static GitHubLabel Parse(JObject json) {
        return new GitHubLabel(json);
    }

    #endregion

}