using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Content;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesRawEndpoint {

        #region CreateContent(...)

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The options for the request to the API.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse CreateContent(string owner, string repositoryAlias, string path, string message, string content) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
            return CreateContent(new GitHubCreateRepositoryContentOptions(owner, repositoryAlias, path, message, content));
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
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse CreateContent(string owner, string repositoryAlias, string path, string message, string content, string branch) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
            return CreateContent(new GitHubCreateRepositoryContentOptions(owner, repositoryAlias, path, message, content, branch));
        }

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse CreateContent(GitHubRepositoryBase repository, string path, string message, string content) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
            return CreateContent(new GitHubCreateRepositoryContentOptions(repository, path, message, content));
        }
        
        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="message">The commit message.</param>
        /// <param name="content">The new file content, using Base64 encoding.</param>
        /// <param name="branch">The name of the branch name. Uses the the default branch if not specified.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse CreateContent(GitHubRepositoryBase repository, string path, string message, string content, string branch) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(message)) throw new ArgumentNullException(nameof(message));
            if (string.IsNullOrWhiteSpace(content)) throw new ArgumentNullException(nameof(content));
            return CreateContent(new GitHubCreateRepositoryContentOptions(repository, path, message, content, branch));
        }

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse CreateContent(GitHubCreateRepositoryContentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetContent(...)

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public IHttpResponse GetContent(string owner, string repositoryAlias, string path) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            return GetContent(new GitHubGetRepositoryContentOptions(owner, repositoryAlias, path, null));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="owner">The alias of the user or organization who own the repository.</param>
        /// <param name="repositoryAlias">The alias/slug of the repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="ref">The name of the commit/branch/tag.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public IHttpResponse GetContent(string owner, string repositoryAlias, string path, string @ref) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repositoryAlias)) throw new ArgumentNullException(nameof(repositoryAlias));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(@ref)) throw new ArgumentNullException(nameof(@ref));
            return GetContent(new GitHubGetRepositoryContentOptions(owner, repositoryAlias, path, @ref));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public IHttpResponse GetContent(GitHubRepositoryBase repository, string path) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            return GetContent(new GitHubGetRepositoryContentOptions(repository, path, null));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="path">The path to the file or directory.</param>
        /// <param name="ref">The name of the commit/branch/tag.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public IHttpResponse GetContent(GitHubRepositoryBase repository, string path, string @ref) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            if (string.IsNullOrWhiteSpace(path)) throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrWhiteSpace(@ref)) throw new ArgumentNullException(nameof(@ref));
            return GetContent(new GitHubGetRepositoryContentOptions(repository, path, @ref));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public IHttpResponse GetContent(GitHubGetRepositoryContentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region UpdateContent(...)

        /// <summary>
        /// Updates/replaces an existing file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse UpdateContent(GitHubUpdateRepositoryContentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}