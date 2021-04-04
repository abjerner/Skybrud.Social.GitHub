using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Branches;

namespace Skybrud.Social.GitHub.Responses.Branches {

    /// <summary>
    /// Class representing the response with information about a GitHub branch.
    /// </summary>
    public class GitHubBranchResponse : GitHubResponse<GitHubBranch> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubBranchResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubBranch.Parse);
        }

    }

}