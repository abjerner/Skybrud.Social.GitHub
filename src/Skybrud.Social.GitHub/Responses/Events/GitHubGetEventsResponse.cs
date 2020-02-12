using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Events;

namespace Skybrud.Social.GitHub.Responses.Events {

    /// <summary>
    /// Class representing the response for getting a list of events.
    /// </summary>
    public class GitHubGetEventsResponse : GitHubListResponse<GitHubEventItem> {

        #region Constructors

        private GitHubGetEventsResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubEventItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetEventsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetEventsResponse"/> representing the response.</returns>
        public static GitHubGetEventsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetEventsResponse(response);
        }

        #endregion

    }

}