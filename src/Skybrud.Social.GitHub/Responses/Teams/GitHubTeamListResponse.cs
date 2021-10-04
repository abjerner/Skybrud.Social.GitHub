using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Teams;

namespace Skybrud.Social.GitHub.Responses.Teams {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubTeamItem"/>.
    /// </summary>
    public class GitHubTeamListResponse : GitHubListResponse<GitHubTeamItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubTeamListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubTeamItem.Parse);
        }

    }

}