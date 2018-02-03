using System;
using Skybrud.Social.GitHub.Models.Commits;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response of a call to get information about a given commit.
    /// </summary>
    public class GitHubGetCommitResponse : GitHubResponse<GitHubCommit> {

        #region Constructors

        private GitHubGetCommitResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, GitHubCommit.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetCommitResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitResponse"/> representing the response.</returns>
        public static GitHubGetCommitResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetCommitResponse(response);
        }

        #endregion

    }

}