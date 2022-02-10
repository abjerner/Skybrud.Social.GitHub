using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Repositories.Collaborators;
using Skybrud.Social.GitHub.Responses;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        #region AddCollaborator(...)

        /// <summary>
        /// Adds the user with <paramref name="username"/> as a collaborator to the repository matching the specified
        /// <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="username">The the username of the user to be added as a collaborator.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
        /// </see>
        public GitHubResponse AddCollaborator(string owner, string repositoryAlias, string username) {
            return new GitHubResponse(Raw.AddCollaborator(owner, repositoryAlias, username));
        }

        /// <summary>
        /// Adds the user with <paramref name="username"/> as a collaborator to <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="username">The username of the user to be added as a collaborator.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
        /// </see>
        public GitHubResponse AddCollaborator(GitHubRepositoryBase repository, string username) {
            return new GitHubResponse(Raw.AddCollaborator(repository, username));
        }

        /// <summary>
        /// Adda <paramref name="user"/> as a collaborator to the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="user">The user to be added as a collaborator.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
        /// </see>
        public GitHubResponse AddCollaborator(GitHubRepositoryBase repository, GitHubUserBase user) {
            return new GitHubResponse(Raw.AddCollaborator(repository, user));
        }

        /// <summary>
        /// Adda a new collaborator to the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
        /// </see>
        public GitHubResponse AddCollaborator(GitHubAddCollaboratorOptions options) {
            return new GitHubResponse(Raw.AddCollaborator(options));
        }

        #endregion

        #region GetCollaborators(...)

        /// <summary>
        /// Returns a list of collaborators of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
        /// </see>
        public GitHubUserListResponse GetCollaborators(string owner, string repositoryAlias) {
            return new GitHubUserListResponse(Raw.GetCollaborators(owner, repositoryAlias));
        }

        /// <summary>
        /// Returns a list of collaborators of the repository matching the specified <paramref name="owner"/> and <paramref name="repositoryAlias"/>.
        /// </summary>
        /// <param name="owner">The username of the parent user or organization.</param>
        /// <param name="repositoryAlias">The alias of the repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
        /// </see>
        public GitHubUserListResponse GetCollaborators(string owner, string repositoryAlias, int perPage, int page) {
            return new GitHubUserListResponse(Raw.GetCollaborators(owner, repositoryAlias, perPage, page));
        }

        /// <summary>
        /// Returns a list of collaborators of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
        /// </see>
        public GitHubUserListResponse GetCollaborators(GitHubRepositoryBase repository) {
            return new GitHubUserListResponse(Raw.GetCollaborators(repository));
        }

        /// <summary>
        /// Returns a list of collaborators of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
        /// </see>
        public GitHubUserListResponse GetCollaborators(GitHubRepositoryBase repository, int perPage, int page) {
            return new GitHubUserListResponse(Raw.GetCollaborators(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of teams of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#list-repository-collaborators</cref>
        /// </see>
        public GitHubUserListResponse GetCollaborators(GitHubGetCollaboratorsOptions options) {
            return new GitHubUserListResponse(Raw.GetCollaborators(options));
        }

        #endregion

    }

}