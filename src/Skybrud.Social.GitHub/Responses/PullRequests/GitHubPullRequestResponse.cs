using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.PullRequests;

namespace Skybrud.Social.GitHub.Responses.PullRequests {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubPullRequest"/>.
    /// </summary>
    public class GitHubPullRequestResponse : GitHubResponse<GitHubPullRequest> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubPullRequestResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubPullRequest.Parse);
        }

    }

}