using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Commits;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubCommit"/>.
    /// </summary>
    public class GitHubCommitResponse : GitHubResponse<GitHubCommit> {
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubCommitResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubCommit.Parse);
        }

    }

}