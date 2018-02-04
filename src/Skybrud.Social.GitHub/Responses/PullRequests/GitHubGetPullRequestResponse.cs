using System;
using Skybrud.Social.GitHub.Models.PullRequests;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.PullRequests {

    /// <summary>
    /// Class representing the response for a single pull request.
    /// </summary>
    public class GitHubGetPullRequestResponse : GitHubResponse<GitHubPullRequest> {

        #region Constructors

        private GitHubGetPullRequestResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, GitHubPullRequest.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetPullRequestResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestResponse"/> representing the response.</returns>
        public static GitHubGetPullRequestResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetPullRequestResponse(response);
        }

        #endregion

    }

}