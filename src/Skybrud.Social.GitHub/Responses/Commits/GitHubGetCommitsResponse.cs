using System;
using Skybrud.Social.GitHub.Models.Commits;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response for getting a list of commits.
    /// </summary>
    public class GitHubGetCommitsResponse : GitHubResponse<GitHubCommitSummary[]> {

        #region Constructor

        private GitHubGetCommitsResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubCommitSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetCommitsResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetCommitsResponse</code> representing the response.</returns>
        public static GitHubGetCommitsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetCommitsResponse(response);

        }

        #endregion

    }

}