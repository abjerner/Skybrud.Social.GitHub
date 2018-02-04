using System;
using Skybrud.Social.GitHub.Models.PullRequests;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting a list of pull requests of a GitHub repositories.
    /// </summary>
    public class GitHubGetPullRequestsResponse : GitHubResponse<GitHubPullRequestItem[]> {

        #region Constructors

        private GitHubGetPullRequestsResponse(SocialHttpResponse response) : base(response) {

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
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestsResponse"/> representing the response.</returns>
        public static GitHubGetPullRequestsResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetPullRequestsResponse(response);
        }

        #endregion

    }

}