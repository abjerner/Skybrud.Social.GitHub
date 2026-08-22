using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Users;

/// <summary>
/// Class representing a collection of URLs related to a GitHub user.
/// </summary>
public class GitHubUserUrls {

    #region Properties

    /// <summary>
    /// Gets the API URL of the user.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the website URL of the user.
    /// </summary>
    public string HtmlUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of followers of the user.
    /// </summary>
    public string FollowersUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of other users the user is following.
    /// </summary>
    public string FollowingUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of gists of the user.
    /// </summary>
    public string GistsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of repositories the user has starred.
    /// </summary>
    public string StarredUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of repositories to which the user has subscribed.
    /// </summary>
    public string SubscriptionsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of organisation of which the user is a member.
    /// </summary>
    public string OrganizationsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of repositories of the user.
    /// </summary>
    public string ReposUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of events made by the user.
    /// </summary>
    public string EventsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of events of repositories to which the user has subscribed.
    /// </summary>
    public string ReceivedEventsUrl { get; }

    #endregion

    #region Constructors

    private GitHubUserUrls(JObject json) {
        Url = json.GetRequiredString("url");
        HtmlUrl = json.GetRequiredString("html_url");
        FollowersUrl = json.GetRequiredString("followers_url");
        FollowingUrl = json.GetRequiredString("following_url");
        GistsUrl = json.GetRequiredString("gists_url");
        StarredUrl = json.GetRequiredString("starred_url");
        SubscriptionsUrl = json.GetRequiredString("subscriptions_url");
        OrganizationsUrl = json.GetRequiredString("organizations_url");
        ReposUrl = json.GetRequiredString("repos_url");
        EventsUrl = json.GetRequiredString("events_url");
        ReceivedEventsUrl = json.GetRequiredString("received_events_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubUserUrls"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubUserUrls"/>.</returns>
    public static GitHubUserUrls Parse(JObject json) {
        return new GitHubUserUrls(json);
    }

    #endregion

}