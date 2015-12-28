using Newtonsoft.Json.Linq;
using Skybrud.Social.Json.Extensions.JObject;

namespace Skybrud.Social.GitHub.Objects.Commits {
    
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
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubCommitParent</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubCommitParent</code>.</returns>
        public static GitHubCommitParent Parse(JObject obj) {
            if (obj == null) return null;
            return new GitHubCommitParent(obj) {
                Sha = obj.GetString("sha"),
                Url = obj.GetString("url"),
                HtmlUrl = obj.GetString("html_url")
            };
        }

        #endregion

    }

}