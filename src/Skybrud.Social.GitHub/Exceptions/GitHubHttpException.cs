using System.Net;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Exceptions;
using Skybrud.Social.GitHub.Models.Common;

namespace Skybrud.Social.GitHub.Exceptions {

    /// <summary>
    /// Class representing an exception returned by the GitHub API.
    /// </summary>
    public class GitHubHttpException : GitHubException, IHttpException {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw response.
        /// </summary>
        public IHttpResponse Response { get; }

        /// <summary>
        /// Gets the status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode => Response.StatusCode;

        /// <summary>
        /// Gets the error information from the response.
        /// </summary>
        public GitHubError Error { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response of the exception.</param>
        public GitHubHttpException(IHttpResponse response) : base("Invalid response received from the GitHub API (Status: " + (int) response.StatusCode + ")") {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The raw response of the exception.</param>
        /// <param name="message">The message of the exception.</param>
        public GitHubHttpException(IHttpResponse response, string message) : base(message) {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="error"/>.
        /// </summary>
        /// <param name="response">The raw response of the exception.</param>
        /// <param name="error">The error information from the response.</param>
        public GitHubHttpException(IHttpResponse response, GitHubError error) : base("Invalid response received from the GitHub API (Status: " + (int) response.StatusCode + ")") {
            Response = response;
            Error = error;
        }

        #endregion

    }

}