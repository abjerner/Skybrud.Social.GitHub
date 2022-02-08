using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a summary about a given repository.
    /// </summary>
    public class GitHubRepositoryItem : GitHubRepositoryBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the repository.</param>
        protected GitHubRepositoryItem(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepositoryItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryItem"/>.</returns>
        public static new GitHubRepositoryItem Parse(JObject json) {
            return json == null ? null : new GitHubRepositoryItem(json);
        }

        #endregion

    }

}