using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Releases {

    /// <summary>
    /// Class describing a GitHub release.
    /// </summary>
    public class GitHubReleaseItem : GitHubReleaseBase {
        
        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubReleaseItem(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubReleaseItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReleaseItem"/>.</returns>
        public static new GitHubReleaseItem Parse(JObject json) {
            return json == null ? null : new GitHubReleaseItem(json);
        }

        #endregion

    }

}