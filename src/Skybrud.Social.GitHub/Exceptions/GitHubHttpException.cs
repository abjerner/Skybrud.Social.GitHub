using System.Net;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Exceptions {

    /// <summary>
    /// Class representing an exception returned by the GitHub API.
    /// </summary>
    public class GitHubHttpException : GitHubException {

        #region Properties

        /// <summary>
        /// Gets a reference to the raw response.
        /// </summary>
        public SocialHttpResponse Response { get; private set; }

        /// <summary>
        /// Gets the status code of the response.
        /// </summary>
        public HttpStatusCode StatusCode {
            get { return Response.StatusCode; }
        }

        /// <summary>
        /// Gets an URL to the GitHub documentation with more information about the exception.
        /// </summary>
        public string DocumentationUrl { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response of the exception.</param>
        public GitHubHttpException(SocialHttpResponse response) : base("Invalid response received from the GitHub API (Status: " + ((int) response.StatusCode) + ")") {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The raw response of the exception.</param>
        /// <param name="message">The message of the exception.</param>
        public GitHubHttpException(SocialHttpResponse response, string message) : base(message) {
            Response = response;
        }

        /// <summary>
        /// Initializes a new exception based on the specified <paramref name="response"/> and <paramref name="message"/>.
        /// </summary>
        /// <param name="response">The raw response of the exception.</param>
        /// <param name="message">The message of the exception.</param>
        /// <param name="documentationUrl">The URL to GitHub documentation about the exception.</param>
        public GitHubHttpException(SocialHttpResponse response, string message, string documentationUrl) : base(message) {
            Response = response;
            DocumentationUrl = documentationUrl;
        }

        #endregion

    }

}