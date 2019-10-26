using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting a list of GitHub repositories.
    /// </summary>
    public class GitHubGetRepositoriesResponse : GitHubResponse<GitHubRepositoryItem[]> {

        #region Constructors

        private GitHubGetRepositoriesResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubRepositoryItem.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetRepositoriesResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetRepositoriesResponse"/> representing the response.</returns>
        public static GitHubGetRepositoriesResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetRepositoriesResponse(response);
        }

        #endregion

    }

}