using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.Repositories;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Repositories</strong> endpoint.
    /// </summary>
    public class GitHubRepositoriesEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubRepositoriesRawEndpoint Raw => Service.Client.Repositories;

        #endregion

        #region Constructors

        internal GitHubRepositoriesEndpoint(GitHubService service) {
            Service = service;
        }

        #endregion

        #region Methods
        
        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetRepositoryResponse"/> representing the response.</returns>
        public GitHubGetRepositoryResponse GetRepository(string owner, string repository) {
            return GitHubGetRepositoryResponse.ParseResponse(Raw.GetRepository(owner, repository));
        }


        /// <summary>
        /// Creates a new repository using a repository template.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubCreateRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create-repository-using-a-repository-template</cref>
        /// </see>
        public GitHubCreateRepositoryResponse CreateRepositoryFromTemplate(GitHubCreateRepositoryFromTemplateOptions options) {
            return GitHubCreateRepositoryResponse.ParseResponse(Raw.CreateRepositoryFromTemplate(options));
        }

        /// <summary>
        /// Creates a new repository for the authenticated user.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubCreateRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubCreateRepositoryResponse CreateUserRepository(GitHubCreateUserRepositoryOptions options) {
            return GitHubCreateRepositoryResponse.ParseResponse(Raw.CreateUserRepository(options));
        }

        /// <summary>
        /// Creates a new repository in the specified organization. The authenticated user must be a member of the organization.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instanceo of <see cref="GitHubCreateRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://developer.github.com/v3/repos/#create</cref>
        /// </see>
        public GitHubCreateRepositoryResponse CreateOrganisationRepository(GitHubCreateOrganisationRepositoryOptions options) {
            return GitHubCreateRepositoryResponse.ParseResponse(Raw.CreateOrganisationRepository(options));
        }

        #endregion
    
    }

}