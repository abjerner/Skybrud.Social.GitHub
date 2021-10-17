using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Tags;

namespace Skybrud.Social.GitHub.Responses.Tags {

    /// <summary>
    /// Class representing the response for a list of <see cref="GitHubTagItem"/>.
    /// </summary>
    public class GitHubTagListResponse : GitHubListResponse<GitHubTagItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubTagListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubTagItem.Parse);
        }

    }

}