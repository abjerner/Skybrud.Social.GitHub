using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Content;
using Skybrud.Social.GitHub.Responses.Repositories.Content;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        #region CreateContent(...)

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The options for the request to the API.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse CreateContent(string owner, string repositoryAlias, string path, string message, string content) {
            return new GitHubContentResponse(Raw.CreateContent(owner, repositoryAlias, path, message, content));
        }

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The options for the request to the API.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <param name="branch">The name of the branch name. Uses the the default branch if not specified.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse CreateContent(string owner, string repositoryAlias, string path, string message, string content, string branch) {
            return new GitHubContentResponse(Raw.CreateContent(owner, repositoryAlias, path, message, content, branch));
        }

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse CreateContent(GitHubRepositoryBase repository, string path, string message, string content) {
            return new GitHubContentResponse(Raw.CreateContent(repository, path, message, content));
        }

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <param name="branch">The name of the branch name. Uses the the default branch if not specified.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse CreateContent(GitHubRepositoryBase repository, string path, string message, string content, string branch) {
            return new GitHubContentResponse(Raw.CreateContent(repository, path, message, content, branch));
        }

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse CreateContent(GitHubCreateRepositoryContentOptions options) {
            return new GitHubContentResponse(Raw.CreateContent(options));
        }

        #endregion

        #region GetContent(...)

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public GitHubContentResponse GetContent(string owner, string repositoryAlias, string path) {
            return new GitHubContentResponse(Raw.GetContent(owner, repositoryAlias, path));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="ref">The name of the commit/branch/tag.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public GitHubContentResponse GetContent(string owner, string repositoryAlias, string path, string @ref) {
            return new GitHubContentResponse(Raw.GetContent(owner, repositoryAlias, path, @ref));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public GitHubContentResponse GetContent(GitHubRepositoryBase repository, string path) {
            return new GitHubContentResponse(Raw.GetContent(repository, path));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="ref">The name of the commit/branch/tag.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public GitHubContentResponse GetContent(GitHubRepositoryBase repository, string path, string @ref) {
            return new GitHubContentResponse(Raw.GetContent(repository, path, @ref));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public GitHubContentResponse GetContent(GitHubGetRepositoryContentOptions options) {
            return new GitHubContentResponse(Raw.GetContent(options));
        }

        #endregion

        #region UpdateContent(...)

        /// <summary>
        /// Updates/replaces an existing file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse UpdateContent(GitHubUpdateRepositoryContentOptions options) {
            return new GitHubContentResponse(Raw.UpdateContent(options));
        }

        #endregion

    }

}