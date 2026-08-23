using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Repositories;

/// <summary>
/// Class representing a GitHub repository.
/// </summary>
public class GitHubRepository : GitHubRepositoryItem {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent organization, if any.
    /// </summary>
    public GitHubUserItem? Organization { get; }

    #endregion

    #region Constructors

    private GitHubRepository(JObject json) : base(json) {
        Organization = json.GetObject("organization", GitHubUserItem.Parse);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepository"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubRepository"/>.</returns>
    public static new GitHubRepository Parse(JObject json) {
        return new GitHubRepository(json);
    }

    #endregion

}