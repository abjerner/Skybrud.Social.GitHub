using System;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw <strong>Repositories</strong> endpoint.
    /// </summary>
    public class GitHubRepositoriesRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent OAuth client.
        /// </summary>
        public GitHubOAuthClient Client { get; }

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
        /// Gets information about the repository matching the specified <paramref name="owner"/> and
        /// <paramref name="repository"/>.
        /// </summary>
        /// <returns>An instance of <see cref="SocialHttpResponse"/> representing the raw response.</returns>
        public SocialHttpResponse GetRepository(string owner, string repository) {
            if (String.IsNullOrWhiteSpace(owner)) throw new ArgumentNullException(nameof(owner));
            if (String.IsNullOrWhiteSpace(repository)) throw new ArgumentNullException(nameof(repository));
            return Client.DoHttpGetRequest("/repos/" + owner + "/" + repository);
        }

        #endregion

    }

}