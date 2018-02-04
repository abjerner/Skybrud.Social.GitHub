using System;
using Skybrud.Essentials.Common;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Organizations;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {
    
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

        #endregion

        #region Constructors

        internal GitHubOrganizationsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets information about the organisation with the specified <paramref name="alias"/>.
        /// </summary>
        /// <param name="alias">The alias (login) of the organization.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetOrganization(string alias) {
            if (String.IsNullOrWhiteSpace(alias)) throw new ArgumentNullException(nameof(alias));
            return Client.DoHttpGetRequest("/orgs/" + alias);
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public SocialHttpResponse GetOrganizations() {
            return Client.DoHttpGetRequest("/user/orgs");
        }

        /// <summary>
        /// Gets the organizations of the authenticated user.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-your-organizations</cref>
        /// </see>
        public SocialHttpResponse GetOrganizations(GitHubGetOrganizationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("/user/orgs", options);
        }
        
        /// <summary>
        /// Gets a list of public organizations of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public SocialHttpResponse GetOrganizations(string username) {
            if (String.IsNullOrWhiteSpace(username)) throw new ArgumentNullException(nameof(username));
            return GetOrganizations(new GitHubGetUserOrganizationsOptions(username));
        }

        /// <summary>
        /// Gets a list of public organizations of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/orgs/#list-user-organizations</cref>
        /// </see>
        public SocialHttpResponse GetOrganizations(GitHubGetUserOrganizationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (String.IsNullOrWhiteSpace(options.Username)) throw new PropertyNotSetException(nameof(options.Username));
            return Client.DoHttpGetRequest($"/users/{options.Username}/orgs");
        }

        #endregion

    }

}