using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Organizations.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsRawEndpoint {

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="org"/>.
        /// </summary>
        /// <param name="org">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse CreateTeam(string org, string name) {
            return Client.GetResponse(new GitHubCreateTeamOptions(org, name));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="name"/> and in the organization with the specified <paramref name="org"/>.
        /// </summary>
        /// <param name="org">The alias/slug og the organization.</param>
        /// <param name="name">The name of the team to be created.</param>
        /// <param name="description">The description of the team to be created.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse CreateTeam(string org, string name, string description) {
            return Client.GetResponse(new GitHubCreateTeamOptions(org, name, description));
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
        /// Gets the teams of the organization with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(int id) {
            return Client.GetResponse(new GitHubGetTeamsOptions(id));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(int id, int page) {
            return Client.GetResponse(new GitHubGetTeamsOptions(id, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(int id, int page, int perPage) {
            return Client.GetResponse(new GitHubGetTeamsOptions(id, page, perPage));
        }
        
        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string alias) {
            return Client.GetResponse(new GitHubGetTeamsOptions(alias));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string alias, int page) {
            return Client.GetResponse(new GitHubGetTeamsOptions(alias, page));
        }

        /// <summary>
        /// Gets the teams of the organization with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias of the organization.</param>
        /// <param name="page">The page to be returned. </param>
        /// <param name="perPage">The maximum amount of teams to be returned by each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetTeams(string alias, int page, int perPage) {
            return Client.GetResponse(new GitHubGetTeamsOptions(alias, page, perPage));
        }

    }

}