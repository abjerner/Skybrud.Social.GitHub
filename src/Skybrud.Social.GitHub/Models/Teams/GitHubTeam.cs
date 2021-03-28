using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Teams {

    /// <summary>
    /// Class representing a GitHub team.
    /// </summary>
    public class GitHubTeam : GitHubTeamItem {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the team.</param>
        protected GitHubTeam(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubTeam"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubTeam"/>.</returns>
        public static new GitHubTeam Parse(JObject json) {
            return json == null ? null : new GitHubTeam(json);
        }

        #endregion

    }

}