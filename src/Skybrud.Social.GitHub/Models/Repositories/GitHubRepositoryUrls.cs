using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Repositories {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub repository.
    /// </summary>
    public class GitHubRepositoryUrls {

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

        private GitHubRepositoryUrls(JObject json) {
            HtmlUrl = json.GetString("html_url");
            Url = json.GetString("url");
            GitUrl = json.GetString("git_url");
            SshUrl = json.GetString("ssh_url");
            CloneUrl = json.GetString("clone_url");
            SvnUrl = json.GetString("svn_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepositoryUrls"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryUrls"/>.</returns>
        public static GitHubRepositoryUrls Parse(JObject json) {
            return json == null ? null : new GitHubRepositoryUrls(json);
        }

        #endregion

    }

}