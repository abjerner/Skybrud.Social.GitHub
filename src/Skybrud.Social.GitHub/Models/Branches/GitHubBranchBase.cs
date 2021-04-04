using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Branches {

    /// <summary>
    /// Class representing a GitHub branch.
    /// </summary>
    public class GitHubBranchBase : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the name of the branch.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets whether the branch is protected.
        /// </summary>
        public bool IsProtected { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the object.</param>
        protected GitHubBranchBase(JObject json) : base(json) {
            Name = json.GetString("name");
            IsProtected = json.GetBoolean("protected");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubBranchBase"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubBranch"/>.</returns>
        public static GitHubBranchBase Parse(JObject json) {
            return json == null ? null : new GitHubBranchBase(json);
        }

        #endregion

    }

}