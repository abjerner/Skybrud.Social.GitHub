using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Teams;

/// <summary>
/// Class representing a collection of URLs related to a GitHub team.
/// </summary>
public class GitHubTeamUrls {

    #region Properties

    /// <summary>
    /// Gets the API URL of the team.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the API URL for getting a list of repositories of the team.
    /// </summary>
    public string ReposUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of events made by members of the team.
    /// </summary>
    public string EventsUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of hooks of the team.
    /// </summary>
    public string HooksUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of issues of the team.
    /// </summary>
    public string IssuesUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of members of the team.
    /// </summary>
    public string MembersUrl { get; }

    /// <summary>
    /// Gets the API URL for getting a list of public members of the team.
    /// </summary>
    public string PublicMembersUrl { get; }

    #endregion

    #region Constructors

    private GitHubTeamUrls(JObject json) {
        Url = json.GetRequiredString("url");
        ReposUrl = json.GetRequiredString("repos_url");
        EventsUrl = json.GetRequiredString("events_url");
        HooksUrl = json.GetRequiredString("hooks_url");
        IssuesUrl = json.GetRequiredString("issues_url");
        MembersUrl = json.GetRequiredString("members_url");
        PublicMembersUrl = json.GetRequiredString("public_members_url");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubTeamUrls"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubTeamUrls"/>.</returns>
    public static GitHubTeamUrls Parse(JObject json) {
        return new GitHubTeamUrls(json);
    }

    #endregion

}