using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Responses.Users {

    /// <summary>
    /// Class representing the response with a list of GitHub users.
    /// </summary>
    public class GitHubUserListResponse : GitHubListResponse<GitHubUserItem> {

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/> response.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public GitHubUserListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubUserItem.Parse);
        }

    }

}