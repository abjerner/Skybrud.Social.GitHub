using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues.Comments;

namespace Skybrud.Social.GitHub.Responses.Issues.Comments {

    /// <summary>
    /// Class representing the response of a single GitHub comment.
    /// </summary>
    public class GitHubCommentResponse : GitHubResponse<GitHubComment> {
        
        #region Constructors

        private GitHubCommentResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubComment.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubCommentResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubCommentResponse"/> representing the response.</returns>
        public static GitHubCommentResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubCommentResponse(response);
        }

        #endregion

    }

}