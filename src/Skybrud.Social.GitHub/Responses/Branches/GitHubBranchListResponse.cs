using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Branches;

namespace Skybrud.Social.GitHub.Responses.Branches {

    /// <summary>
    /// Class representing the response for a list of <see cref="GitHubBranchItem"/>.
    /// </summary>
    public class GitHubBranchListResponse : GitHubListResponse<GitHubBranchItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubBranchListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubBranchItem.Parse);
        }

    }

}