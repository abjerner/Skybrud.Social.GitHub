using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Exceptions;
using Skybrud.Social.GitHub.Models.Common;

namespace Skybrud.Social.GitHub.Responses {

    /// <summary>
    /// Class representing a response from the GitHub API.
    /// </summary>
    public abstract class GitHubResponse : HttpResponseBase {

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
        protected GitHubResponse(IHttpResponse response) : base(response) {

            if (response.Headers["X-RateLimit-Limit"] != null) RateLimiting = GitHubRateLimiting.GetFromResponse(response);
  
            // If an error occurs during authorization, the error code will still be "OK"
            if (response.ContentType.StartsWith("application/x-www-form-urlencoded") && response.Body.StartsWith("error=")) {
                IHttpQueryString body = HttpQueryString.ParseQueryString(response.Body, true);
                throw new GitHubException(body.GetString("error_description"));
            }

            // Skip error checking if the server responds with an OK status code
            if (response.StatusCode == HttpStatusCode.OK) return;
            if (response.StatusCode == HttpStatusCode.Created) return;

            // Parse the error message from the response body
            GitHubError error = ParseJsonObject(response.Body, GitHubError.Parse);

            // Now throw some exceptions
            throw new GitHubHttpException(response, error);

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
        protected GitHubResponse(IHttpResponse response) : base(response) { }

        #endregion

    }

}