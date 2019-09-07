using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Responses.Issues {

    public class GitHubAddIssueCommentResponse : GitHubResponse<GitHubIssueComment> {

        #region Constructors

        private GitHubAddIssueCommentResponse(IHttpResponse response) : base(response) {

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
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubAddIssueCommentResponse"/> representing the response.</returns>
        public static GitHubAddIssueCommentResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubAddIssueCommentResponse(response);
        }

        #endregion

    }

}