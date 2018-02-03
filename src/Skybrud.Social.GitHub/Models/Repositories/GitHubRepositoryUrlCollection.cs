using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub repository.
    /// </summary>
    public class GitHubRepositoryUrlCollection {

        #region Properties

        /// <summary>
        /// Gets the website (HTML) URL of the repository.
        /// </summary>
        public string HtmlUrl { get; }

        /// <summary>
        /// Gets the API URL of the repository.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the Git URL of the repository.
        /// </summary>
        public string GitUrl { get; }

        /// <summary>
        /// Gets the SSH URL of the repository.
        /// </summary>
        public string SshUrl { get; }

        /// <summary>
        /// Gets the clone URL of the repository.
        /// </summary>
        public string CloneUrl { get; }

        /// <summary>
        /// Gets the Subversion URL of the repository.
        /// </summary>
        public string SvnUrl { get; }

        #endregion

        #region Constructors

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
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubRepositoryUrlCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryUrlCollection"/>.</returns>
        public static GitHubRepositoryUrlCollection Parse(JObject obj) {
            return obj == null ? null : new GitHubRepositoryUrlCollection(obj);
        }

        #endregion

    }

}