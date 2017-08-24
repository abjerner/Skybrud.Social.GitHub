using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {
    
    /// <summary>
    /// Class representing statistics about a given commit.
    /// </summary>
    public class GitHubCommitStats : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the total amount of lines modified in the commit.
        /// </summary>
        public int Total { get; private set; }

        /// <summary>
        /// Gets the total amount of lines added in the commit.
        /// </summary>
        public int Additions { get; private set; }
        
        /// <summary>
        /// Gets the total amount of lines deleted in the commit.
        /// </summary>
        public int Deletions { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitStats(JObject obj) : base(obj) {
            Total = obj.GetInt32("total");
            Additions = obj.GetInt32("additions");
            Deletions = obj.GetInt32("deletions");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitStats"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="GitHubCommitStats"/>.</returns>
        public static GitHubCommitStats Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitStats(obj);
        }

        #endregion

    }

}