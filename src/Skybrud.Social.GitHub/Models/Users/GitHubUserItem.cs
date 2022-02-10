using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Users {

    /// <summary>
    /// Class representing a GitHub user.
    /// </summary>
    public class GitHubUserItem : GitHubUserBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the user.</param>
        protected GitHubUserItem(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubUserItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubUserItem"/>.</returns>
        public static new GitHubUserItem Parse(JObject json) {
            return json == null ? null : new GitHubUserItem(json);
        }

        #endregion

    }

}