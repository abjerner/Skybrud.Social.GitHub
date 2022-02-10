using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Search;

namespace Skybrud.Social.GitHub.Responses.Search {

    /// <summary>
    /// Class representing the response with a code search result.
    /// </summary>
    public class GitHubSearchCodeResponse : GitHubResponse<GitHubSearchCodeResult> {

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/> response.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public GitHubSearchCodeResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubSearchCodeResult.Parse);
        }

    }

}