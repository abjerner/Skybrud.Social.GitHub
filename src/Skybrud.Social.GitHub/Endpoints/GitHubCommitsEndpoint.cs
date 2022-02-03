using Skybrud.Social.GitHub.Endpoints.Raw;
using Skybrud.Social.GitHub.Options.Commits;
using Skybrud.Social.GitHub.Responses.Commits;

namespace Skybrud.Social.GitHub.Endpoints {

    /// <summary>
    /// Class representing the <strong>Commits</strong> endpoint.
    /// </summary>
    public class GitHubCommitsEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the GitHub service.
        /// </summary>
        public GitHubHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public GitHubCommitsRawEndpoint Raw => Service.Client.Commits;

        #endregion

        #region Constructors

        internal GitHubCommitsEndpoint(GitHubHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the commit matching the specified <paramref name="owner"/>,
        /// <paramref name="repository"/> and <paramref name="sha"/> hash.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="sha">The SHA hash of the commit.</param>
        /// <returns>An instance of <see cref="GitHubCommitResponse"/> representing the response.</returns>
        public GitHubCommitResponse GetCommit(string owner, string repository, string sha) {
            return new GitHubCommitResponse(Raw.GetCommit(owner, repository, sha));
        }

        /// <summary>
        /// Gets information about the commit matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubCommitResponse"/> representing the response.</returns>
        public GitHubCommitResponse GetCommit(GitHubGetCommitOptions options) {
            return new GitHubCommitResponse(Raw.GetCommit(options));
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <returns>An instance of <see cref="GitHubCommitListResponse"/> representing the response.</returns>
        public GitHubCommitListResponse GetCommits(string owner, string repository) {
            return new GitHubCommitListResponse(Raw.GetCommits(owner, repository));
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="GitHubCommitListResponse"/> representing the response.</returns>
        public GitHubCommitListResponse GetCommits(GitHubGetCommitsOptions options) {
            return new GitHubCommitListResponse(Raw.GetCommits(options));
        }

        #endregion

    }

}