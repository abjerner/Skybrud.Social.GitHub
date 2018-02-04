using System.Net;
using Newtonsoft.Json.Linq;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.Http;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models.Common;

namespace Skybrud.Social.GitHub.Responses {

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public abstract class GitHubResponse : SocialResponse {

        #region Properties

        /// <summary>
        /// Gets information about rate limiting.
        /// </summary>
        public GitHubRateLimiting RateLimiting { get; }

        /// <summary>
        /// Gets whether rate limiting informatyion is available for this response. 
        /// </summary>
        public bool HasRateLimit => RateLimiting != null;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        protected GitHubResponse(SocialHttpResponse response) : base(response) {
            if (response.Headers["X-RateLimit-Limit"] != null) RateLimiting = GitHubRateLimiting.GetFromResponse(response);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Validates the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The response to be validated.</param>
        public static void ValidateResponse(SocialHttpResponse response) {

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;

            // Get the "meta" object
            JObject obj = ParseJsonObject(response.Body);

            // Now throw some exceptions
            string message = obj.GetString("message");
            string url = obj.GetString("documentation_url");
            throw new GitHubHttpException(response, message, url);

        }

        #endregion

    }

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public class GitHubResponse<T> : GitHubResponse {

        #region Properties

        /// <summary>
        /// Gets the body of the response.
        /// </summary>
        public T Body { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        protected GitHubResponse(SocialHttpResponse response) : base(response) { }

        #endregion

    }

}