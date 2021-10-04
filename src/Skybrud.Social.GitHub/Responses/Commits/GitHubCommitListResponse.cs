using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Commits;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubCommitSummary"/>.
    /// </summary>
    public class GitHubCommitListResponse : GitHubListResponse<GitHubCommitSummary> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubCommitListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubCommitSummary.Parse);
        }

    }

}