using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.PullRequests;

namespace Skybrud.Social.GitHub.Responses.PullRequests {

    /// <summary>
    /// Class representing the response for a single pull request.
    /// </summary>
    public class GitHubGetPullRequestResponse : GitHubResponse<GitHubPullRequest> {

        #region Constructors

        private GitHubGetPullRequestResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubPullRequest.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetPullRequestResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetPullRequestResponse"/> representing the response.</returns>
        public static GitHubGetPullRequestResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetPullRequestResponse(response);
        }

        #endregion

    }

}