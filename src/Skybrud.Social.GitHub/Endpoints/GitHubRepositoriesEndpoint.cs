using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.Commits;
using Skybrud.Social.GitHub.Responses.Commits;
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
        /// Gets information about the commit matching the specified <paramref name="owner"/>,
        /// <paramref name="repository"/> and <paramref name="sha"/> hash.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="sha">The SHA hash of the commit.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitResponse"/> representing the response.</returns>
        public GitHubGetCommitResponse GetCommit(string owner, string repository, string sha) {
            return GitHubGetCommitResponse.ParseResponse(Raw.GetCommit(owner, repository, sha));
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitsResponse"/> representing the response.</returns>
        public GitHubGetCommitsResponse GetCommits(string owner, string repository) {
            return GitHubGetCommitsResponse.ParseResponse(Raw.GetCommits(owner, repository));
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitsResponse"/> representing the response.</returns>
        public GitHubGetCommitsResponse GetCommits(GitHubGetCommitsOptions options) {
            return GitHubGetCommitsResponse.ParseResponse(Raw.GetCommits(options));
        }

        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="GitHubGetRepositoryResponse"/> representing the response.</returns>
        public GitHubGetRepositoryResponse GetRepository(string owner, string repository) {
            return GitHubGetRepositoryResponse.ParseResponse(Raw.GetRepository(owner, repository));
        }

        #endregion
    
    }

}