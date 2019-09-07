using Skybrud.Social.GitHub.Endpoints.Raw;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Issues/Events</strong> endpoint.
    /// </summary>
    public class GitHubIssuesEventsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubIssuesEventsRawEndpoint Raw => Service.Client.Issues.Events;

        #endregion

        #region Constructors

        internal GitHubIssuesEventsEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods

        

        #endregion

    }

}