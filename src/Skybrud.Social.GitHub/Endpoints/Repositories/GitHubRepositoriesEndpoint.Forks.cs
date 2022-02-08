using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Forks;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        /// <summary>
        /// Creates a new fork of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public GitHubRepositoryResponse CreateFork(string owner, string repository) {
            return new GitHubRepositoryResponse(Raw.CreateFork(owner, repository));
        }

        /// <summary>
        /// Creates a new fork of the repository matching the specified <paramref name="owner"/> and <paramref name="repository"/> alias.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repository">The alias/slug of the repository.</param>
        /// <param name="organization">The alias of the organization for which the fork will be created.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public GitHubRepositoryResponse CreateFork(string owner, string repository, string organization) {
            return new GitHubRepositoryResponse(Raw.CreateFork(owner, repository, organization));
        }

        /// <summary>
        /// Creates a new fork of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public GitHubRepositoryResponse CreateFork(GitHubRepositoryBase repository) {
            return new GitHubRepositoryResponse(Raw.CreateFork(repository));
        }

        /// <summary>
        /// Creates a new fork of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="organization">The alias of the organization for which the fork will be created.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public GitHubRepositoryResponse CreateFork(GitHubRepositoryBase repository, string organization) {
            return new GitHubRepositoryResponse(Raw.CreateFork(repository, organization));
        }

        /// <summary>
        /// Creates a new fork matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-a-fork</cref>
        /// </see>
        public GitHubRepositoryResponse CreateFork(GitHubCreateForkOptions options) {
            return new GitHubRepositoryResponse(Raw.CreateFork(options));
        }

    }

}