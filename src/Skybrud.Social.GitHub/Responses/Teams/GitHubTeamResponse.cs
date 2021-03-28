using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Teams;

namespace Skybrud.Social.GitHub.Responses.Teams {

    /// <summary>
    /// Class representing the response with information about a GitHub user.
    /// </summary>
    public class GitHubTeamResponse : GitHubResponse<GitHubTeam> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubTeamResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubTeam.Parse);
        }

    }

}