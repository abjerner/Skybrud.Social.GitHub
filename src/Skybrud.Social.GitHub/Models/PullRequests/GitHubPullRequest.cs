using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.PullRequests;

/// <summary>
/// Class representing a GitHub pull request.
/// </summary>
public class GitHubPullRequest : GitHubPullRequestBase {

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the pull request.</param>
    protected GitHubPullRequest(JObject json) : base(json) { }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubPullRequest"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubPullRequest"/>.</returns>
    public static new GitHubPullRequest Parse(JObject json) {
        return new GitHubPullRequest(json);
    }

    #endregion

}