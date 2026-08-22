using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.PullRequests;

/// <summary>
/// Class representing a collection of URLs related to a GitHub pull request.
/// </summary>
public class GitHubPullRequestUrls {

    #region Properties

    /// <summary>
    /// Gets the API URL of the user.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the website URL of the issue.
    /// </summary>
    public string HtmlUrl { get; }

    /// <summary>
    /// Gets the diff URL of the pull request.
    /// </summary>
    public string DiffUrl { get; }

    /// <summary>
    /// Gets the patch URL of the pull request.
    /// </summary>
    public string PatchUrl { get; }

    /// <summary>
    /// Gets the API URL of the underlying issue.
    /// </summary>
    public string IssueUrl { get; }

    /// <summary>
    /// Gets for API URL for getting the commits made to this pull request.
    /// </summary>
    public string CommitsUrl { get; }

    /// <summary>
    /// Gets the review comments URL of the pull request.
    /// </summary>
    public string ReviewCommentsUrl { get; }

    /// <summary>
    /// Gets the review comment URL of the pull request.
    /// </summary>
    public string ReviewCommentUrl { get; }

    /// <summary>
    /// Gets the comments URL of the pull request.
    /// </summary>
    public string CommentsUrl { get; }

    /// <summary>
    /// Gets the statuses URL of the pull request.
    /// </summary>
    public string StatusesUrl { get; }

    #endregion

    #region Constructors

    private GitHubPullRequestUrls(JObject json) {
        Url = json.GetRequiredString("url");
        HtmlUrl = json.GetRequiredString("html_url");
        DiffUrl = json.GetRequiredString("diff_url");
        PatchUrl = json.GetRequiredString("patch_url");
        IssueUrl = json.GetRequiredString("issue_url");
        CommitsUrl = json.GetRequiredString("commits_url");
        ReviewCommentsUrl = json.GetRequiredString("review_comments_url");
        ReviewCommentUrl = json.GetRequiredString("review_comment_url");
        CommentsUrl = json.GetRequiredString("comments_url");
        StatusesUrl = json.GetRequiredString("statuses_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubPullRequestUrls"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubPullRequestUrls"/>.</returns>
    public static GitHubPullRequestUrls Parse(JObject json) {
        return new GitHubPullRequestUrls(json);
    }

    #endregion

}