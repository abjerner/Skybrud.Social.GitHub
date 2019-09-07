using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.PullRequests;

namespace Skybrud.Social.GitHub.Responses.PullRequests {

    /// <summary>
    /// Class representing the response for getting a list of pull requests of a GitHub repositories.
    /// </summary>
    public class GitHubGetPullRequestsResponse : GitHubResponse<GitHubPullRequestItem[]> {

        #region Constructors

        private GitHubGetPullRequestsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, GitHubPullRequestItem.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetPullRequestsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestsResponse"/> representing the response.</returns>
        public static GitHubGetPullRequestsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetPullRequestsResponse(response);
        }

        #endregion

    }

}