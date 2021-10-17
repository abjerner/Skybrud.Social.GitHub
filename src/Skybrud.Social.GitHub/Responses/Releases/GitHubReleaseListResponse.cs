using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Releases;

namespace Skybrud.Social.GitHub.Responses.Releases {

    /// <summary>
    /// Class representing the response for a list of <see cref="GitHubReleaseItem"/>.
    /// </summary>
    public class GitHubReleaseListResponse : GitHubListResponse<GitHubReleaseItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubReleaseListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubReleaseItem.Parse);
        }

    }

}