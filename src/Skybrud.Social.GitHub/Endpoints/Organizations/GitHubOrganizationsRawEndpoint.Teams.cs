using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Organizations.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsRawEndpoint {

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse CreateTeam(string organizationAlias, string name) {
            return Client.GetResponse(new GitHubCreateTeamOptions(organizationAlias, name));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <param name="description">The description of the team to be created.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse CreateTeam(string organizationAlias, string name, string description) {
            return Client.GetResponse(new GitHubCreateTeamOptions(organizationAlias, name, description));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse CreateTeam(GitHubCreateTeamOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(int organizationId) {
            return Client.GetResponse(new GitHubGetTeamsOptions(organizationId));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(int organizationId, int page) {
            return Client.GetResponse(new GitHubGetTeamsOptions(organizationId, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(int organizationId, int page, int perPage) {
            return Client.GetResponse(new GitHubGetTeamsOptions(organizationId, page, perPage));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string organizationAlias) {
            return Client.GetResponse(new GitHubGetTeamsOptions(organizationAlias));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string organizationAlias, int page) {
            return Client.GetResponse(new GitHubGetTeamsOptions(organizationAlias, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string organizationAlias, int page, int perPage) {
            return Client.GetResponse(new GitHubGetTeamsOptions(organizationAlias, page, perPage));
        }

    }

}