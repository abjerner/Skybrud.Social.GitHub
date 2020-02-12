using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Common {

    /// <summary>
    /// Class representing an individual error of an error response.
    /// </summary>
    public class GitHubErrorItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the message.
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Gets the name of the affected resource.
        /// </summary>
        public string Resource { get; }

        /// <summary>
        /// Gets the code of the error.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets the name of the affected field.
        /// </summary>
        public string Field { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The an instance of <see cref="JObject"/> representing the error.</param>
        protected GitHubErrorItem(JObject obj) : base(obj) {
            Message = obj.GetString("message");
            Resource = obj.GetString("resource");
            Code = obj.GetString("code");
            Field = obj.GetString("field");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubErrorItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubErrorItem"/>.</returns>
        public static GitHubErrorItem Parse(JObject obj) {
            return obj == null ? null : new GitHubErrorItem(obj);
        }

        #endregion

    }

}