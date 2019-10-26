using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Repositories;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for a created GitHub repository.
    /// </summary>
    public class GitHubCreateRepositoryResponse : GitHubResponse<GitHubRepository> {

        #region Constructors

        private GitHubCreateRepositoryResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubRepository.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetRepositoryResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetRepositoryResponse"/> representing the response.</returns>
        public static GitHubCreateRepositoryResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubCreateRepositoryResponse(response);
        }

        #endregion

    }

}