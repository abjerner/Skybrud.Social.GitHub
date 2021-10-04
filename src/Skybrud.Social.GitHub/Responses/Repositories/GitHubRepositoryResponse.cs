using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing a response with information about a <see cref="GitHubRepository"/>.
    /// </summary>
    public class GitHubRepositoryResponse : GitHubResponse<GitHubRepository> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubRepositoryResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubRepository.Parse);
        }

    }

}