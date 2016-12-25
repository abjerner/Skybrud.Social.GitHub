using System;
using Skybrud.Social.GitHub.Objects.Users;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Users {

    /// <summary>
    /// Class representing the response for getting a list of GitHub users.
    /// </summary>
    public class GitHubGetUsersResponse : GitHubResponse<GitHubUserSummary[]> {

        #region Constructor

        private GitHubGetUsersResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubUserSummary.Parse);
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetUsersResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetUsersResponse</code> representing the response.</returns>
        public static GitHubGetUsersResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetUsersResponse(response);

        }

    }

}