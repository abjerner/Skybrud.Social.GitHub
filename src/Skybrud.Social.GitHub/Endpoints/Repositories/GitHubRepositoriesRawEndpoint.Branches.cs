using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Branches;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesRawEndpoint {

        #region GetBranch(...)

        /// <summary>
        /// Returns the branch matching the specified <paramref name="owner"/>, <paramref name="repo"/> slug and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the branch.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public IHttpResponse GetBranch(string owner, string repo, string name) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return GetBranch(new GitHubGetBranchOptions(owner, repo, name));
        }

        /// <summary>
        /// Returns the branch matching the specified <paramref name="repository"/> and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the branch.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public IHttpResponse GetBranch(GitHubRepositoryBase repository, string name) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetBranch(new GitHubGetBranchOptions(repository, name));
        }

        /// <summary>
        /// Returns the branch matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public IHttpResponse GetBranch(GitHubGetBranchOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

        #region GetBranches(...)

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public IHttpResponse GetBranches(string owner, string repo) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
            return GetBranches(new GitHubGetBranchesOptions(owner, repo));
        }

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="perPage">The maximum amount of branches to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public IHttpResponse GetBranches(string owner, string repo, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (string.IsNullOrWhiteSpace(repo)) throw new ArgumentNullException(nameof(repo));
            return GetBranches(new GitHubGetBranchesOptions(owner, repo, perPage, page));
        }

        /// <summary>
        /// Returns a list of branches of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public IHttpResponse GetBranches(GitHubRepositoryBase repository) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetBranches(new GitHubGetBranchesOptions(repository));
        }

        /// <summary>
        /// Returns a list of branches of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of branches to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public IHttpResponse GetBranches(GitHubRepositoryBase repository, int perPage, int page) {
            if (repository == null) throw new ArgumentNullException(nameof(repository));
            return GetBranches(new GitHubGetBranchesOptions(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public IHttpResponse GetBranches(GitHubGetBranchesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}