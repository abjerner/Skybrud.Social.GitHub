using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.GitHub.Objects.Emails;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Emails {

    /// <summary>
    /// Class representing the response of a call to get a list of emails of the authenticated user.
    /// </summary>
    public class GitHubGetEmailsResponse : GitHubResponse<GitHubEmail[]> {

        #region Constructor

        private GitHubGetEmailsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetEmailsResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetEmailsResponse</code> representing the response.</returns>
        public static GitHubGetEmailsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetEmailsResponse(response) {
                Body = ParseJsonArray(response.Body, GitHubEmail.Parse)
            };

        }

    }

}