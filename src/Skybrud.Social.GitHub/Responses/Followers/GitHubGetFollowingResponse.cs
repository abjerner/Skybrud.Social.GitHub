using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Exceptions;
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
        public bool IsFollowing { get; }

        #endregion

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubGetFollowingResponse(IHttpResponse response) : base(response) {

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

    }

}