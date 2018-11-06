using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models.Common;

namespace Skybrud.Social.GitHub.Responses.Followers {

    /// <summary>
    /// Class representing the response of a call to get whether the authenticated is following a given user.
    /// </summary>
    public class GitHubGetFollowingResponse : GitHubResponse {

        #region Properties

        /// <summary>
        /// Gets whether the authenticated user is following the specified user.
        /// </summary>
        public bool IsFollowing { get; private set; }

        #endregion

        #region Constructor

        private GitHubGetFollowingResponse(SocialHttpResponse response) : base(response) {

            switch (response.StatusCode) {

                case HttpStatusCode.NoContent:
                    IsFollowing = true;
                    break;

                case HttpStatusCode.NotFound:
                    IsFollowing = false;
                    break;

                default:

                    // Parse the raw JSON response
                    GitHubError error = ParseJsonObject(response.Body, GitHubError.Parse);
                    throw new GitHubHttpException(response, error);

            }

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetFollowingResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetFollowingResponse"/> representing the response.</returns>
        public static GitHubGetFollowingResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new GitHubGetFollowingResponse(response);
        }

        #endregion

    }

}