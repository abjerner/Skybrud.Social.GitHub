using System;
using Skybrud.Social.GitHub.Models.Repositories;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting information about a GitHub repository.
    /// </summary>
    public class GitHubGetRepositoryResponse : GitHubResponse<GitHubRepository> {

        #region Constructor

        private GitHubGetRepositoryResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubRepository.Parse);
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetRepositoryResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetRepositoryResponse</code> representing the response.</returns>
        public static GitHubGetRepositoryResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetRepositoryResponse(response);

        }

    }

}