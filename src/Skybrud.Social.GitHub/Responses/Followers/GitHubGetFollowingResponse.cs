using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Essentials.Json.Extensions;

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
                    JObject obj = ParseJsonObject(response.Body);

                    string message = obj.GetString("message");
                    string url = obj.GetString("documentation_url");
                    throw new GitHubHttpException(response, message, url);

            }

        }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetFollowingResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetFollowingResponse</code> representing the response.</returns>
        public static GitHubGetFollowingResponse ParseResponse(SocialHttpResponse response) {
            return response == null ? null : new GitHubGetFollowingResponse(response);
        }

    }

}