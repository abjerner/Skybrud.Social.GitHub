using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.PullRequests.Reviews;

namespace Skybrud.Social.GitHub.Responses.PullRequests.Reviews {

    /// <summary>
    /// Class representing the response for list of reviews.
    /// </summary>
    public class GitHubReviewListResponse : GitHubListResponse<GitHubReviewItem> {

        #region Constructors

        private GitHubReviewListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubReviewItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubReviewListResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubReviewListResponse"/> representing the response.</returns>
        public static GitHubReviewListResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubReviewListResponse(response);
        }

        #endregion

    }

}