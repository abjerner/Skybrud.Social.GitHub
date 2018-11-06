using System;
using Skybrud.Social.GitHub.Models.Issues;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Issues {

    public class GitHubAddIssueCommentResponse : GitHubResponse<GitHubIssueComment> {

        #region Constructors

        private GitHubAddIssueCommentResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, GitHubIssueComment.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubAddIssueCommentResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubAddIssueCommentResponse"/> representing the response.</returns>
        public static GitHubAddIssueCommentResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubAddIssueCommentResponse(response);
        }

        #endregion

    }

}