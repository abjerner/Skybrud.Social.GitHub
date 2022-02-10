using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Releases {

    /// <summary>
    /// Class describing a GitHub release.
    /// </summary>
    public class GitHubRelease : GitHubReleaseBase {

        #region Properties

        // GitHubRelease currently offers no additional properties compared to GitHubReleaseItem

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubRelease(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubRelease"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRelease"/>.</returns>
        public static new GitHubRelease Parse(JObject json) {
            return json == null ? null : new GitHubRelease(json);
        }

        #endregion

    }

}