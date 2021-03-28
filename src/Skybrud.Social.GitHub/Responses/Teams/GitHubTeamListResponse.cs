using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Teams;

namespace Skybrud.Social.GitHub.Responses.Teams {

    /// <summary>
    /// Class representing the response for a list of <see cref="GitHubTeam"/>.
    /// </summary>
    public class GitHubTeamListResponse : GitHubListResponse<GitHubTeam> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubTeamListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubTeam.Parse);
        }

    }

}