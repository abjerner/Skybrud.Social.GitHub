using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.PullRequests.Reviews;

namespace Skybrud.Social.GitHub.Responses.PullRequests.Reviews {

    /// <summary>
    /// Class representing the response for list of <see cref="GitHubReviewItem"/>.
    /// </summary>
    public class GitHubReviewListResponse : GitHubListResponse<GitHubReviewItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubReviewListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubReviewItem.Parse);
        }

    }

}