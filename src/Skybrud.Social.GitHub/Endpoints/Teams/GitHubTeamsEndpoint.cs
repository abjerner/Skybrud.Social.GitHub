using Skybrud.Social.GitHub.Options.Organizations.Teams;
using Skybrud.Social.GitHub.Responses.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Teams {

    /// <summary>
    /// Class representing the <strong>Teams</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/teams</cref>
    /// </see>
    public class GitHubTeamsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubTeamsRawEndpoint Raw => Service.Client.Teams;

        #endregion

        #region Constructors

        internal GitHubTeamsEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="organizationId"/> and <paramref name="teamId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the response.</returns>
        public GitHubTeamResponse GetTeam(int organizationId, int teamId) {
            return new GitHubTeamResponse(Raw.GetTeam(organizationId, teamId));
        }

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="organization"/> and <paramref name="team"/>.
        /// </summary>
        /// <param name="organization">The alias/slug of the organization.</param>
        /// <param name="team">The alias/slug of the team.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/teams#get-a-team-by-name</cref>
        /// </see>
        public GitHubTeamResponse GetTeam(string organization, string team) {
            return new GitHubTeamResponse(Raw.GetTeam(organization, team));
        }

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the raw response.</returns>
        public GitHubTeamResponse GetTeam(GitHubGetTeamOptions options) {
            return new GitHubTeamResponse(Raw.GetTeam(options));
        }

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubTeamResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/teams#get-a-team-by-name</cref>
        /// </see>
        public GitHubTeamResponse GetTeam(GitHubGetTeamByNameOptions options) {
            return new GitHubTeamResponse(Raw.GetTeam(options));
        }

        #endregion

    }

}