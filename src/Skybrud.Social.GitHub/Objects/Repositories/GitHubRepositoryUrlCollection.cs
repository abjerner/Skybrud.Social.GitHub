using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Repositories {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub repository.
    /// </summary>
    public class GitHubRepositoryUrlCollection {

        #region Properties

        /// <summary>
        /// Gets the website (HTML) URL of the repository.
        /// </summary>
        public string HtmlUrl { get; private set; }

        /// <summary>
        /// Gets the API URL of the repository.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the Git URL of the repository.
        /// </summary>
        public string GitUrl { get; private set; }

        /// <summary>
        /// Gets the SSH URL of the repository.
        /// </summary>
        public string SshUrl { get; private set; }

        /// <summary>
        /// Gets the clone URL of the repository.
        /// </summary>
        public string CloneUrl { get; private set; }

        /// <summary>
        /// Gets the Subversion URL of the repository.
        /// </summary>
        public string SvnUrl { get; private set; }

        #endregion

        #region Constructor

        private GitHubRepositoryUrlCollection(JObject obj) {
            HtmlUrl = obj.GetString("html_url");
            Url = obj.GetString("url");
            GitUrl = obj.GetString("git_url");
            SshUrl = obj.GetString("ssh_url");
            CloneUrl = obj.GetString("clone_url");
            SvnUrl = obj.GetString("svn_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubRepositoryUrlCollection</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubCommitUrlCollection</code>.</returns>
        public static GitHubRepositoryUrlCollection Parse(JObject obj) {
            return obj == null ? null : new GitHubRepositoryUrlCollection(obj);
        }

        #endregion

    }

}