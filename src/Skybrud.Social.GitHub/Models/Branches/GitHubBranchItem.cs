using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Branches;

/// <summary>
/// Class representing a GitHub branch.
/// </summary>
public class GitHubBranchItem : GitHubBranchBase {

    #region Constructors

    private GitHubBranchItem(JObject json) : base(json) { }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubBranchItem"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubBranch"/>.</returns>
    public static new GitHubBranchItem Parse(JObject json) {
        return new GitHubBranchItem(json);
    }

    #endregion

}