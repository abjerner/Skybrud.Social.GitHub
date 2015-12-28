using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.GitHub.Objects.Commits;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response of a call to get information about a given commit.
    /// </summary>
    public class GitHubGetCommitResponse : GitHubResponse<GitHubCommit> {

        #region Constructor

        private GitHubGetCommitResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetCommitResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetCommitResponse</code> representing the response.</returns>
        public static GitHubGetCommitResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetCommitResponse(response) {
                Body = ParseJsonObject(response.Body, GitHubCommit.Parse)
            };

        }

        #endregion

    }

}