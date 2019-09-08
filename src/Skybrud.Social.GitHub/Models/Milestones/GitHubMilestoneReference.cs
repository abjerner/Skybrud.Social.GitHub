using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Milestones {

    /// <summary>
    /// Class representing a GitHub milestone.
    /// </summary>
    public class GitHubMilestoneReference : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the title of the milestone.
        /// </summary>
        public string Title { get; }

        #endregion

        #region Constructors

        private GitHubMilestoneReference(JObject obj) : base(obj) {
            Title = obj.GetString("title");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubMilestoneReference"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubMilestoneReference"/>.</returns>
        public static GitHubMilestoneReference Parse(JObject obj) {
            return obj == null ? null : new GitHubMilestoneReference(obj);
        }

        #endregion

    }

}