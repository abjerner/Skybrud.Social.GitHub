using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits;

/// <summary>
/// Class representing statistics about a given commit.
/// </summary>
public class GitHubCommitStats : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the total amount of lines modified in the commit.
    /// </summary>
    public int Total { get; }

    /// <summary>
    /// Gets the total amount of lines added in the commit.
    /// </summary>
    public int Additions { get; }

    /// <summary>
    /// Gets the total amount of lines deleted in the commit.
    /// </summary>
    public int Deletions { get; }

    #endregion

    #region Constructors

    private GitHubCommitStats(JObject obj) : base(obj) {
        Total = obj.GetRequiredInt32("total");
        Additions = obj.GetRequiredInt32("additions");
        Deletions = obj.GetRequiredInt32("deletions");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubCommitStats"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubCommitStats"/>.</returns>
    public static GitHubCommitStats Parse(JObject json) {
        return new GitHubCommitStats(json);
    }

    #endregion

}