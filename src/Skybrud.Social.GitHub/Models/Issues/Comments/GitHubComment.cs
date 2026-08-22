using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Issues.Comments;

/// <summary>
/// Class representing a comment of a GitHub issue.
/// </summary>
public class GitHubComment : GitHubObject {

    // TODO: consider renaming to "GitHubIssueComment" to match GitHub's own naming

    #region Properties

    /// <summary>
    /// Gets the ID of the comment.
    /// </summary>
    public long Id { get; }

    /// <summary>
    /// Gets the node ID of the comment.
    /// </summary>
    public string NodeId { get; }

    /// <summary>
    /// Gets the API URL of the comment.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the Markdown-based body of the comment.
    /// </summary>
    public string Body { get; }

    // TODO: add "body_html" and "body_text" properties

    /// <summary>
    /// Gets the web URL of the comment.
    /// </summary>
    public string HtmlUrl { get; }

    /// <summary>
    /// Gets information about the user who created the comment.
    /// </summary>
    public GitHubUserItem? User { get; }

    /// <summary>
    /// Gets a timestamp for when the comment was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the comment was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    /// <summary>
    /// Gets a collection/map of URLs related to the comment.
    /// </summary>
    public GitHubCommentUrlCollection Urls { get; }

    // TODO: add support for the "issue_url" property (string: uri)

    // TODO: add support for the "author_association" property (string/enum)

    // TODO: add support for the "performed_via_github_app" property (object?)

    // TODO: add support for the "reactions" property (ReactionRollup)

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the issue.</param>
    protected GitHubComment(JObject json) : base(json) {
        Id = json.GetRequiredInt64("id");
        NodeId = json.GetRequiredString("node_id");
        Url = json.GetRequiredString("url");
        HtmlUrl = json.GetRequiredString("html_url");
        Body = json.GetRequiredString("body");
        User = json.GetObject("user", GitHubUserItem.Parse);
        CreatedAt = json.GetRequiredEssentialsTime("created_at");
        UpdatedAt = json.GetRequiredEssentialsTime("updated_at");
        Urls = GitHubCommentUrlCollection.Parse(json);
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubComment"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubComment"/>.</returns>
    public static GitHubComment Parse(JObject json) {
        return new GitHubComment(json);
    }

    #endregion

}