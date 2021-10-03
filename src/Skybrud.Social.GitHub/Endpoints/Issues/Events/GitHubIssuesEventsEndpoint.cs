using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.GitHub.Options.Issues.Events;
using Skybrud.Social.GitHub.Responses.Events;

namespace Skybrud.Social.GitHub.Endpoints.Issues.Events {

    /// <summary>
    /// Class representing the <strong>Issues/Events</strong> endpoint.
    /// </summary>
    public class GitHubIssuesEventsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubIssuesEventsRawEndpoint Raw => Service.Client.Issues.Events;

        #endregion

        #region Constructors

        internal GitHubIssuesEventsEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a list of events of the issue matching the specified <paramref name="owner"/>, <paramref name="repository"/> and <paramref name="number"/>.
        /// </summary>
        /// <param name="owner">The username (login) of the owner of the repository.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="number">The number of the issue to which the comment should be added.</param>
        /// <returns>An instance of <see cref="GitHubGetEventsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/events/#list-events-for-an-issue</cref>
        /// </see>
        public GitHubGetEventsResponse GetEvents(string owner, string repository, int number) {
            return GitHubGetEventsResponse.ParseResponse(Raw.GetEvents(owner, repository, number));
        }

        /// <summary>
        /// Gets a list of events of the specified <paramref name="issue"/>.
        /// </summary>
        /// <param name="issue">The issue to get events for.</param>
        /// <returns>An instance of <see cref="GitHubGetEventsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/events/#list-events-for-an-issue</cref>
        /// </see>
        public GitHubGetEventsResponse GetEvents(GitHubIssueBase issue) {
            return GitHubGetEventsResponse.ParseResponse(Raw.GetEvents(issue));
        }

        /// <summary>
        /// Gets a list of events of the issue matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetEventsResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/issues/events/#list-events-for-an-issue</cref>
        /// </see>
        public GitHubGetEventsResponse GetEvents(GitHubGetIssueEventsOptions options) {
            return GitHubGetEventsResponse.ParseResponse(Raw.GetEvents(options));
        }

        #endregion

    }

}