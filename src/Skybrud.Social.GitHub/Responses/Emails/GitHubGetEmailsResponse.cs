using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Emails;

namespace Skybrud.Social.GitHub.Responses.Emails {

    /// <summary>
    /// Class representing the response of a call to get a list of emails of the authenticated user.
    /// </summary>
    public class GitHubGetEmailsResponse : GitHubResponse<GitHubEmail[]> {

        #region Constructor

        private GitHubGetEmailsResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubEmail.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetEmailsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetEmailsResponse"/> representing the response.</returns>
        public static GitHubGetEmailsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetEmailsResponse(response);
        }

        #endregion

    }

}