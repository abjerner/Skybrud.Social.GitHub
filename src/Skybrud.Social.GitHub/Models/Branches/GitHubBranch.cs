using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Branches;

/// <summary>
/// Class representing a GitHub branch.
/// </summary>
public class GitHubBranch : GitHubBranchBase {

    #region Constructors

    private GitHubBranch(JObject json) : base(json) { }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubBranch"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubBranch"/>.</returns>
    public static new GitHubBranch Parse(JObject json) {
        return new GitHubBranch(json);
    }

    #endregion

}