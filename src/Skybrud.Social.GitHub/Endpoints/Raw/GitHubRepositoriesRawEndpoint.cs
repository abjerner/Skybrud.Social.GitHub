using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>Repositories</strong> endpoint.
    /// </summary>
    public class GitHubRepositoriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubRepositoriesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepository(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.Get($"/repos/{owner}/{repository}");
        }

        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public IHttpResponse CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public IHttpResponse CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public IHttpResponse CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}