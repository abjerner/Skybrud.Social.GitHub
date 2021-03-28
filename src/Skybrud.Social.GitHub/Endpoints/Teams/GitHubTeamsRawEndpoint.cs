using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Organizations.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Teams {

    /// <summary>
    /// Class representing the raw <strong>Teams</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/teams</cref>
    /// </see>
    public class GitHubTeamsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubTeamsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region member methods

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="organizationId"/> and <paramref name="teamId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="teamId">The ID of the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeam(int organizationId, int teamId) {
            return GetTeam(new GitHubGetTeamOptions(organizationId, teamId));
        }

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="organization"/> and <paramref name="team"/>.
        /// </summary>
        /// <param name="organization">The alias/slug of the organization.</param>
        /// <param name="team">The alias/slug of the team.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/teams#get-a-team-by-name</cref>
        /// </see>
        public IHttpResponse GetTeam(string organization, string team) {
            if (string.IsNullOrWhiteSpace(organization)) throw new ArgumentNullException(nameof(organization));
            if (string.IsNullOrWhiteSpace(team)) throw new ArgumentNullException(nameof(team));
            return GetTeam(new GitHubGetTeamByNameOptions(organization, team));
        }

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeam(GitHubGetTeamOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets information about the team matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/teams#get-a-team-by-name</cref>
        /// </see>
        public IHttpResponse GetTeam(GitHubGetTeamByNameOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}