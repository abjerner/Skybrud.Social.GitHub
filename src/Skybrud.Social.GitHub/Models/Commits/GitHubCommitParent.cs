using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Commits {
    
    /// <summary>
    /// Class representing the parent commit of a given commit.
    /// </summary>
    public class GitHubCommitParent : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the SHA hash of the commit.
        /// </summary>
        public string Sha { get; private set; }
        
        /// <summary>
        /// Gets the API URL of the commit.
        /// </summary>
        public string Url { get; private set; }
        
        /// <summary>
        /// Gets the HTML (website) URL of the commit.
        /// </summary>
        public string HtmlUrl { get; private set; }
        
        #endregion

        #region Constructor

        private GitHubCommitParent(JObject obj) : base(obj) {
            Sha = obj.GetString("sha");
            Url = obj.GetString("url");
            HtmlUrl = obj.GetString("html_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubCommitParent"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="GitHubCommitParent"/>.</returns>
        public static GitHubCommitParent Parse(JObject obj) {
            return obj == null ? null : new GitHubCommitParent(obj);
        }

        #endregion

    }

}