using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Commits;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>Commits</strong> endpoint.
    /// </summary>
    public class GitHubCommitsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal GitHubCommitsRawEndpoint(GitHubOAuthClient client) {
            Client = client;
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
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetCommit(string owner, string repository, string sha) {
            if (String.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (String.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            if (String.IsNullOrWhiteSpace(sha)) throw new ArgumentNullException(nameof(sha));
            return Client.DoHttpGetRequest("/repos/" + owner + "/" + repository + "/commits/" + sha);
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetCommits(string owner, string repository) {
            if (String.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (String.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.DoHttpGetRequest("/repos/" + owner + "/" + repository + "/commits");
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetCommits(GitHubGetCommitsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("/repos/" + options.Owner + "/" + options.Repository + "/commits", options);
        }

        #endregion

    }

}