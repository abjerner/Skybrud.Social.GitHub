using System;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Users {

    /// <summary>
    /// Class representing the response for getting a list of GitHub users.
    /// </summary>
    public class GitHubGetUsersResponse : GitHubResponse<GitHubUserItem[]> {

        #region Constructors

        private GitHubGetUsersResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, GitHubUserItem.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetUsersResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetUsersResponse"/> representing the response.</returns>
        public static GitHubGetUsersResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetUsersResponse(response);
        }

        #endregion

    }

}