using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Events {

    /// <summary>
    /// Class representing rename details from an event.
    /// </summary>
    public class GitHubEventRenameDetails : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the title or name before the rename.
        /// </summary>
        public string From { get; }

        /// <summary>
        /// Gets the title or name after the rename.
        /// </summary>
        public string To { get; }

        #endregion

        #region Constructors

        private GitHubEventRenameDetails(JObject obj) : base(obj) {
            From = obj.GetString("from");
            To = obj.GetString("to");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubEventRenameDetails"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubEventRenameDetails"/>.</returns>
        public static GitHubEventRenameDetails Parse(JObject obj) {
            return obj == null ? null : new GitHubEventRenameDetails(obj);
        }

        #endregion

    }

}