using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Branches {

    /// <summary>
    /// Class representing the commit a GitHub branch.
    /// </summary>
    public class GitHubBranchCommit : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the SHA1 hash of the commit.
        /// </summary>
        public string Sha { get; }

        /// <summary>
        /// Gets the API URL of the commit.
        /// </summary>
        public string Url { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected GitHubBranchCommit(JObject json) : base(json) {
            Sha = json.GetString("sha");
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubBranchCommit"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubBranchCommit"/>.</returns>
        public static GitHubBranchCommit Parse(JObject json) {
            return json == null ? null : new GitHubBranchCommit(json);
        }

        #endregion

    }

}