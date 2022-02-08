using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json;
using Skybrud.Social.GitHub.Models.Repositories.Content;

namespace Skybrud.Social.GitHub.Responses.Repositories.Content {

    /// <summary>
    /// Class representing a response with the contents of a file in a GitHub repository.
    /// </summary>
    public class GitHubContentResponse : GitHubResponse<GitHubContent> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubContentResponse(IHttpResponse response) : base(response) {
            Body = JsonUtils.ParseJsonObject(response.Body, GitHubContent.Parse);
        }

    }

}