using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Common {

    /// <summary>
    /// Class representing an error as returned by the GitHub API.
    /// </summary>
    public class GitHubError : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the error message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets an array of errors.
        /// </summary>
        public string[] Errors { get; }

        /// <summary>
        /// Gets whether the <see cref="Errors"/> property has any items.
        /// </summary>
        public bool HasErrors => Errors.Length > 0;

        /// <summary>
        /// Gets an URL with information about the error.
        /// </summary>
        public string DocumentationUrl { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The an instance of <see cref="JObject"/> representing the error.</param>
        protected GitHubError(JObject obj) : base(obj) {
            Message = obj.GetString("message");
            Errors = obj.GetStringArray("errors");
            DocumentationUrl = obj.GetString("documentation_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubError"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubError"/>.</returns>
        public static GitHubError Parse(JObject obj) {
            return obj == null ? null : new GitHubError(obj);
        }

        #endregion

    }

}