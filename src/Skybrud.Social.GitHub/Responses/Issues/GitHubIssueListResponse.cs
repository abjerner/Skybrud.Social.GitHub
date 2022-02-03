using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Responses.Issues {

    /// <summary>
    /// Class representing the response for getting a list of <see cref="GitHubIssueItem"/>.
    /// </summary>
    public class GitHubIssueListResponse : GitHubListResponse<GitHubIssueItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubIssueListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubIssueItem.Parse);
        }

    }

}