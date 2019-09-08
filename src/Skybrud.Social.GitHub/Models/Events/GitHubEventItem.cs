using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Events {

    /// <summary>
    /// Class representing a GitHub event.
    /// </summary>
    public class GitHubEventItem : GitHubEventBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the event.</param>
        protected GitHubEventItem(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubEventItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubEventItem"/>.</returns>
        public static GitHubEventItem Parse(JObject obj) {
            return obj == null ? null : new GitHubEventItem(obj);
        }

        #endregion

    }

}