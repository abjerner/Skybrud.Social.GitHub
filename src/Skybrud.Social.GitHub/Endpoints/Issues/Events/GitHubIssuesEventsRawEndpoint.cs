using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Issues.Events;

namespace Skybrud.Social.GitHub.Endpoints.Issues.Events;

/// <summary>
/// Class representing the raw <strong>Issues/Events</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developer.github.com/v3/issues/events/</cref>
/// </see>
public class GitHubIssuesEventsRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    #endregion

    #region Constructors

    internal GitHubIssuesEventsRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets a list of events of the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
    /// </summary>
    /// <param name="owner">The username (login) of the owner of the repository.</param>
    /// <param name="repository">The slug of the repository.</param>
    /// <param name="number">The number of the issue to which the comment should be added.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/events/#list-events-for-an-issue</cref>
    /// </see>
    public async Task<IHttpResponse> GetEvents(string owner, string repository, int number) {
        if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
        if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
        return await GetEvents(new GitHubGetIssueEventsOptions(owner, repository, number));
    }

    /// <summary>
    /// Gets a list of events of the specified <paramref name="issue"/>.
    /// </summary>
    /// <param name="issue">The issue to get events for.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/events/#list-events-for-an-issue</cref>
    /// </see>
    public async Task<IHttpResponse> GetEvents(GitHubIssueBase issue) {
        if (issue == null) throw new ArgumentNullException(nameof(issue));
        return await GetEvents(new GitHubGetIssueEventsOptions(issue));
    }

    /// <summary>
    /// Gets a list of events of the issue matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/events/#list-events-for-an-issue</cref>
    /// </see>
    public async Task<IHttpResponse> GetEvents(GitHubGetIssueEventsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    #endregion

}