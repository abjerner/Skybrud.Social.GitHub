using System;
using Skybrud.Social.GitHub.Objects.Users;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Users {

    /// <summary>
    /// Class representing the response for getting information about a GitHub user.
    /// </summary>
    public class GitHubGetUserResponse : GitHubResponse<GitHubUser> {

        #region Constructor

        private GitHubGetUserResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubUser.Parse);
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetUserResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetUserResponse</code> representing the response.</returns>
        public static GitHubGetUserResponse ParseResponse(SocialHttpResponse response) {
            
            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetUserResponse(response);

        }

    }

}