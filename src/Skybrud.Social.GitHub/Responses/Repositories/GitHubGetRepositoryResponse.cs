using System;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting information about a GitHub repository.
    /// </summary>
    public class GitHubGetRepositoryResponse : GitHubResponse<GitHubRepository> {

        #region Constructors

        private GitHubGetRepositoryResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, GitHubRepository.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetRepositoryResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetRepositoryResponse"/> representing the response.</returns>
        public static GitHubGetRepositoryResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetRepositoryResponse(response);
        }

        #endregion

    }

}