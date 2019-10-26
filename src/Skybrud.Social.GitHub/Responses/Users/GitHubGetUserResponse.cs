using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Responses.Users {

    /// <summary>
    /// Class representing the response for getting information about a GitHub user.
    /// </summary>
    public class GitHubGetUserResponse : GitHubResponse<GitHubUser> {

        #region Constructors

        private GitHubGetUserResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubUser.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetUserResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetUserResponse"/> representing the response.</returns>
        public static GitHubGetUserResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetUserResponse(response);
        }

        #endregion

    }

}