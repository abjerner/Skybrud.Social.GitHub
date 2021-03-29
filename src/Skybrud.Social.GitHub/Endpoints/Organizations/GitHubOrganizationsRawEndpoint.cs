using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.Teams;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {
    
    /// <summary>
    /// Class representing the raw <strong>Organizations</strong> endpoint.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/orgs/</cref>
    /// </see>
    public class GitHubOrganizationsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Organizations/Members</strong> endpoint.
        /// </summary>
        public GitHubOrganizationMembersRawEndpoint Members { get; }

        /// <summary>
        /// Gets a reference to the raw <strong>Organizations/OutsideCollaborators</strong> endpoint.
        /// </summary>
        public GitHubOrganizationOutsideCollaboratorsRawEndpoint OutsideCollaborators { get; }

        #endregion

        #region Constructors

        internal GitHubOrganizationsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
            Members = new GitHubOrganizationMembersRawEndpoint(client);
            OutsideCollaborators = new GitHubOrganizationOutsideCollaboratorsRawEndpoint(client);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="id"/>.
        /// </summary>
        /// <param name="id">The ID of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetOrganization(int id) {
            return Client.Get($"/organizations/{id}");
        }

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetOrganization(string alias) {
            if (string.IsNullOrWhiteSpace(alias)) throw new ArgumentNullException(nameof(alias));
            return Client.Get($"/orgs/{alias}");
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public IHttpResponse GetOrganizations() {
            return Client.Get("/user/orgs");
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public IHttpResponse GetOrganizations(GitHubGetOrganizationsOptions options) {

            // TODO: consider new name, as name may collide with https://api.github.com/organizations

            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.Get("/user/orgs", options);
        }
        
        /// <summary>
        /// Gets a list of public organizations of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public IHttpResponse GetOrganizations(string username) {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetOrganizations(new GitHubGetUserOrganizationsOptions(username));
        }

        /// <summary>
        /// Gets a list of public organizations of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public IHttpResponse GetOrganizations(GitHubGetUserOrganizationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (string.IsNullOrWhiteSpace(options.Username)) throw new PropertyNotSetException(nameof(options.Username));
            return Client.Get($"/users/{options.Username}/orgs");
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
            return Client.GetResponse(new GitHubCreateTeamOptions(org, name));
        }

        /// <summary>
        /// Creates a new team with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse CreateTeam(GitHubCreateTeamOptions options) {
            return Client.GetResponse(options);
        }
        
        #endregion

    }

}