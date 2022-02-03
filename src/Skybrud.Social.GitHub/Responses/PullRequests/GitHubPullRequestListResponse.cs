using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.PullRequests;

namespace Skybrud.Social.GitHub.Responses.PullRequests {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubPullRequestItem"/>.
    /// </summary>
    public class GitHubPullRequestListResponse : GitHubListResponse<GitHubPullRequestItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubPullRequestListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubPullRequestItem.Parse);
        }

    }

}