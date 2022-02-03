using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Responses.Users {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubUser"/>.
    /// </summary>
    public class GitHubUserResponse : GitHubResponse<GitHubUser> {

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/> response.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public GitHubUserResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubUser.Parse);
        }

    }

}