using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Responses.Issues {

    /// <summary>
    /// Class representing the response describing a single GitHub issue.
    /// </summary>
    public class GitHubIssueResponse : GitHubResponse<GitHubIssue> {

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/> response.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public GitHubIssueResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubIssue.Parse);
        }

    }

}