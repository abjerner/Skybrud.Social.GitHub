using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Teams {

    /// <summary>
    /// Class representing a GitHub team.
    /// </summary>
    public class GitHubTeamItem : GitHubTeamBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the team.</param>
        protected GitHubTeamItem(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubTeamItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubTeamItem"/>.</returns>
        public static new GitHubTeamItem Parse(JObject json) {
            return json == null ? null : new GitHubTeamItem(json);
        }

        #endregion

    }

}