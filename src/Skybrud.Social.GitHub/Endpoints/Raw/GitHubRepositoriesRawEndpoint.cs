using System;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Commits;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw repositories endpoint.
    /// </summary>
    public class GitHubRepositoriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; private set; }

        #endregion

        #region Constructors

        internal GitHubRepositoriesRawEndpoint(GitHubOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Methods

        /*public string GetContents(string owner, string repository, string path) {
            return SocialUtils.DoHttpGetRequestAndGetBodyAsString(
                Client.GenerateAbsoluteUrl(String.Format("/repos/{0}/{1}/contents/{2}", owner, repository, path))
            );
        }*/

        /// <summary>
        /// Gets information about the commit matching the specified <paramref name="owner"/>,
        /// <paramref name="repository"/> and <paramref name="sha"/> hash.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <param name="sha">The SHA hash of the commit.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetCommit(string owner, string repository, string sha) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository + "/commits/" + sha);
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <param name="owner">The alias (login) of the owner.</param>
        /// <param name="repository">The slug of the repository.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetCommits(string owner, string repository) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository + "/commits");
        }

        /// <summary>
        /// Gets a list of commits of the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetCommits(GitHubGetCommitOptions options) {
            if (options == null) throw new ArgumentNullException("options");
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + options.Owner + "/" + options.Repository + "/commits", options);
        }

        /// <summary>
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetRepository(string owner, string repository) {
            return Client.DoAuthenticatedGetRequest("https://api.github.com/repos/" + owner + "/" + repository);
        }

        #endregion

    }

}