using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.PullRequests.Reviews;

/// <summary>
///
/// </summary>
public class GitHubReviewItem : GitHubObject {

    #region Properties

    /// <summary>
    /// Gets the ID of the review.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the review.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets a reference to the user who made the review.
    /// </summary>
    public GitHubUserItem? User { get; } // TODO: is this nullable?

    /// <summary>
    /// Gets the body of the review.
    /// </summary>
    public string Body { get; }

    /// <summary>
    /// Gets the state of the review.
    /// </summary>
    public GitHubReviewState State { get; }

    /// <summary>
    /// Gets the GitHub website URL of the review.
    /// </summary>
    public string HtmlUrl { get; }

    /// <summary>
    /// Gets the pull request URL of the review.
    /// </summary>
    public string PullRequestUrl { get; }

    // TODO: Add support for the "author_association" property

    // TODO: Add support for the "_links" property

    /// <summary>
    /// Gets a timestamp for when the review was submitted.
    /// </summary>
    public EssentialsTime SubmittedAt { get; }

    // TODO: Add support for the "commit_id" property

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/> object.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the pull request.</param>
    protected GitHubReviewItem(JObject json) : base(json) {
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        User = json.GetObject("user", GitHubUserItem.Parse);
        Body = json.GetRequiredString("body");
        State = json.GetRequiredEnum<GitHubReviewState>("state");
        HtmlUrl = json.GetRequiredString("html_url");
        PullRequestUrl = json.GetRequiredString("pull_request_url");
        // TODO: Add support for the "author_association" property
        // TODO: Add support for the "_links" property
        SubmittedAt = json.GetRequiredEssentialsTime("submitted_at");
        // TODO: Add support for the "commit_id" property
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubReviewItem"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubReviewItem"/>.</returns>
    public static GitHubReviewItem Parse(JObject json) {
        return new GitHubReviewItem(json);
    }

    #endregion

}