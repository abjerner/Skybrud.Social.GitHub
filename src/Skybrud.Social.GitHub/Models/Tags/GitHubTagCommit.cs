using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Tags {
    
    /// <summary>
    /// Class describing the commit a GitHub tag is based on.
    /// </summary>
    public class GitHubTagCommit : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets SHA hash of the commit.
        /// </summary>
        public string Sha { get; }

        /// <summary>
        /// Gets the API URL of the commit.
        /// </summary>
        public string Url { get; }

        #endregion

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubTagCommit(JObject json) : base(json) {
            Sha = json.GetString("sha");
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods
        
        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubTagCommit"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubTagCommit"/>.</returns>
        public static GitHubTagCommit Parse(JObject json) {
            return json == null ? null : new GitHubTagCommit(json);
        }

        #endregion

    }

}