using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Issues.Comments;

/// <summary>
/// Class representing a collection of URLs related to a GitHub comment.
/// </summary>
public class GitHubCommentUrlCollection {

    #region Properties

    /// <summary>
    /// Gets the API URL of the comment.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the website URL of the comment.
    /// </summary>
    public string HtmlUrl { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="json"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> representing the issue.</param>
    protected GitHubCommentUrlCollection(JObject json) {
        Url = json.GetRequiredString("url");
        HtmlUrl = json.GetRequiredString("html_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubCommentUrlCollection"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubCommentUrlCollection"/>.</returns>
    public static GitHubCommentUrlCollection Parse(JObject json) {
        return new GitHubCommentUrlCollection(json);
    }

    #endregion

}