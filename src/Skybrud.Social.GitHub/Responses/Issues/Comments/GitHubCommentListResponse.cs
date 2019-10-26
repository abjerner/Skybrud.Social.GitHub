using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues.Comments;

namespace Skybrud.Social.GitHub.Responses.Issues.Comments {

    /// <summary>
    /// Class representing the response with a list of issue comments.
    /// </summary>
    public class GitHubCommentListResponse : GitHubListResponse<GitHubComment> {
        
        #region Constructors

        private GitHubCommentListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubComment.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubCommentListResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubCommentListResponse"/> representing the response.</returns>
        public static GitHubCommentListResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubCommentListResponse(response);
        }

        #endregion

    }

}