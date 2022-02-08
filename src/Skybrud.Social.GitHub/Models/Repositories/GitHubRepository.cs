using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Models.Users;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a GitHub repository.
    /// </summary>
    public class GitHubRepository : GitHubRepositoryBase {

        #region Properties

        /// <summary>
        /// Gets a reference to the parent organization, if any.
        /// </summary>
        public GitHubUser Organization { get; }

        /// <summary>
        /// Gets the network count of the repository.
        /// </summary>
        public int NetworkCount { get; }

        /// <summary>
        /// Gets the amount of users who have subscribed (watchers) to the repository.
        /// </summary>
        public int SubscribersCount { get; }

        #endregion

        #region Constructors

        private GitHubRepository(JObject json) : base(json) {
            Organization = json.GetObject("organization", GitHubUser.Parse);
            NetworkCount = json.GetInt32("network_count");
            SubscribersCount = json.GetInt32("subscribers_count");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepository"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepository"/>.</returns>
        public static new GitHubRepository Parse(JObject json) {
            return json == null ? null : new GitHubRepository(json);
        }

        #endregion

    }

}