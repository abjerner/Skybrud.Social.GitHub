using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.GitHub.Options.Repositories.Branches;
using Skybrud.Social.GitHub.Responses.Branches;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        #region GetBranch(...)

        /// <summary>
        /// Returns the branch matching the specified <paramref name="owner"/>, <paramref name="repo"/> slug and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <param name="name">The name of the branch.</param>
        /// <returns>An instance of <see cref="GitHubBranchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public GitHubBranchResponse GetBranch(string owner, string repo, string name) {
            return new GitHubBranchResponse(Raw.GetBranch(owner, repo, name));
        }

        /// <summary>
        /// Returns the branch matching the specified <paramref name="repository"/> and branch <paramref name="name"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="name">The name of the branch.</param>
        /// <returns>An instance of <see cref="GitHubBranchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public GitHubBranchResponse GetBranch(GitHubRepositoryBase repository, string name) {
            return new GitHubBranchResponse(Raw.GetBranch(repository, name));
        }

        /// <summary>
        /// Returns the branch matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubBranchResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-a-branch</cref>
        /// </see>
        public GitHubBranchResponse GetBranch(GitHubGetBranchOptions options) {
            return new GitHubBranchResponse(Raw.GetBranch(options));
        }

        #endregion

        #region GetBranches(...)

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="owner"/> and <paramref name="repo"/> slug.
        /// </summary>
        /// <param name="owner">The alias of the repository owner.</param>
        /// <param name="repo">The alias/slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubBranchListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public GitHubBranchListResponse GetBranches(string owner, string repo) {
            return new GitHubBranchListResponse(Raw.GetBranches(owner, repo));
        }

        /// <summary>
        /// Returns a list of branches of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <returns>An instance of <see cref="GitHubBranchListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public GitHubBranchListResponse GetBranches(GitHubRepositoryBase repository) {
            return new GitHubBranchListResponse(Raw.GetBranches(repository));
        }

        /// <summary>
        /// Returns a list of branches of the specified <paramref name="repository"/>.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="perPage">The maximum amount of branches to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="GitHubBranchListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public GitHubBranchListResponse GetBranches(GitHubRepositoryBase repository, int perPage, int page) {
            return new GitHubBranchListResponse(Raw.GetBranches(repository, perPage, page));
        }

        /// <summary>
        /// Returns a list of branches of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubBranchListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#list-branches</cref>
        /// </see>
        public GitHubBranchListResponse GetBranches(GitHubGetBranchesOptions options) {
            return new GitHubBranchListResponse(Raw.GetBranches(options));
        }

        #endregion

    }

}