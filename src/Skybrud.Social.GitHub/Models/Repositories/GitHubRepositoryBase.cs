using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Repositories;

/// <summary>
/// Class representing a summary about a given repository.
/// </summary>
public class GitHubRepositoryBase : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the repository.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the repository.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets the name of the repository - e.g. <code>Skybrud.Social</code>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the full name of the repository - e.g. <code>abjerner/Skybrud.Social</code>.
    /// </summary>
    public string FullName { get; }

    /// <summary>
    /// Gets information about the owner of the repository.
    /// </summary>
    public GitHubUserItem Owner { get; }

    /// <summary>
    /// Gets whether the repository is private.
    /// </summary>
    public bool IsPrivate { get; }

    /// <summary>
    /// Gets the description of the repository.
    /// </summary>
    public string? Description { get; }

    /// <summary>
    /// Gets whether the repository is a fork.
    /// </summary>
    public bool IsFork { get; }

    /// <summary>
    /// Gets a reference to a collection of URLs related to the repository.
    /// </summary>
    public GitHubRepositoryUrls Urls { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
    protected GitHubRepositoryBase(JObject json) : base(json) {
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        Name = json.GetRequiredString("name");
        FullName = json.GetRequiredString("full_name");
        Owner = json.GetRequiredObject("owner", GitHubUserItem.Parse);
        IsPrivate = json.GetBoolean("private");
        Description = json.GetString("description");
        IsFork = json.GetBoolean("fork");
        Urls = GitHubRepositoryUrls.Parse(json);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepositoryBase"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubRepositoryBase"/>.</returns>
    public static GitHubRepositoryBase Parse(JObject json) {
        return new GitHubRepositoryBase(json);
    }

    #endregion

}