using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Issues;

/// <summary>
/// Class representing a collection of URLs related to a GitHub issue.
/// </summary>
public class GitHubIssueUrls {

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
    /// Gets the API URL for getting the repository of the issue.
    /// </summary>
    public string RepositoryUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of labels of the issue.
    /// </summary>
    public string LabelsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of comments of the issue.
    /// </summary>
    public string CommentsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of events of the issue.
    /// </summary>
    public string EventsUrl { get; }

    #endregion

    #region Constructors

    private GitHubIssueUrls(JObject obj) {
        Url = obj.GetRequiredString("url");
        HtmlUrl = obj.GetRequiredString("html_url");
        RepositoryUrl = obj.GetRequiredString("repository_url");
        LabelsUrl = obj.GetRequiredString("labels_url");
        CommentsUrl = obj.GetRequiredString("comments_url");
        EventsUrl = obj.GetRequiredString("events_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubIssueUrls"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubIssueUrls"/>.</returns>
    public static GitHubIssueUrls Parse(JObject json) {
        return new GitHubIssueUrls(json);
    }

    #endregion

}