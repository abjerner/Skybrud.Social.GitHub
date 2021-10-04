using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting a list of <see cref="GitHubRepositoryItem"/>.
    /// </summary>
    public class GitHubRepositoryListResponse : GitHubListResponse<GitHubRepositoryItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubRepositoryListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubRepositoryItem.Parse);
        }

    }

}