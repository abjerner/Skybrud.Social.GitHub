using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.GitHub.Objects.Repositories;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Repositories {

    /// <summary>
    /// Class representing the response for getting a list of GitHub repositories.
    /// </summary>
    public class GitHubGetRepositoriesResponse : GitHubResponse<GitHubRepositorySummary[]> {

        #region Constructor

        private GitHubGetRepositoriesResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetRepositoriesResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetRepositoriesResponse</code> representing the response.</returns>
        public static GitHubGetRepositoriesResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetRepositoriesResponse(response) {
                Body = ParseJsonArray(response.Body, GitHubRepositorySummary.Parse)
            };

        }

    }

}