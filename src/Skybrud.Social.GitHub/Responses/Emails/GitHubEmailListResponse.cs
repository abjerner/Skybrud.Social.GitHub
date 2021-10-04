using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Emails;

namespace Skybrud.Social.GitHub.Responses.Emails {

    /// <summary>
    /// Class representing the response with a list of emails of the authenticated user.
    /// </summary>
    public class GitHubEmailListResponse : GitHubListResponse<GitHubEmail> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubEmailListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubEmail.Parse);
        }

    }

}