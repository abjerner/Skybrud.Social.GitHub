using System;
using Skybrud.Essentials.Http;

namespace Skybrud.Social.GitHub.Responses.Issues.Comments {

    public class GitHubDeleteCommentResponse : GitHubResponse {
        
        #region Constructors

        private GitHubDeleteCommentResponse(IHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubDeleteCommentResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubDeleteCommentResponse"/> representing the response.</returns>
        public static GitHubDeleteCommentResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubDeleteCommentResponse(response);
        }

        #endregion

    }

}