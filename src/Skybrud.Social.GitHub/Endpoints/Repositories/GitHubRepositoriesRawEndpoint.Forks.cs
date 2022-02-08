using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Forks;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesRawEndpoint {

        /// <summary>
        /// Creates a new fork of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public IHttpResponse CreateFork(string owner, string repository) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return CreateFork(new GitHubCreateForkOptions(owner, repository));
        }

        /// <summary>
        /// Creates a new fork of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="organization">The alias of the organization for which the fork will be created.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public IHttpResponse CreateFork(string owner, string repository, string organization) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return CreateFork(new GitHubCreateForkOptions(owner, repository, organization));
        }

        /// <summary>
        /// Creates a new fork of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public IHttpResponse CreateFork(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return CreateFork(new GitHubCreateForkOptions(repository));
        }

        /// <summary>
        /// Creates a new fork of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="organization">The alias of the organization for which the fork will be created.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public IHttpResponse CreateFork(GitHubRepositoryBase repository, string organization) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return CreateFork(new GitHubCreateForkOptions(repository, organization));
        }

        /// <summary>
        /// Creates a new fork matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public IHttpResponse CreateFork(GitHubCreateForkOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}