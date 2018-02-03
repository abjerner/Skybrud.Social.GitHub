using System;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting a list of GitHub repositories.
    /// </summary>
    public class GitHubGetRepositoriesResponse : GitHubResponse<GitHubRepositoryItem[]> {

        #region Constructors

        private GitHubGetRepositoriesResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, GitHubRepositoryItem.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetRepositoriesResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetRepositoriesResponse"/> representing the response.</returns>
        public static GitHubGetRepositoriesResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetRepositoriesResponse(response);
        }

        #endregion

    }

}