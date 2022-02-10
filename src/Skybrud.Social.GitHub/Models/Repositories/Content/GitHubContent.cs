using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Repositories.Content {

    /// <summary>
    /// Class representing the content of a file in a GitHub repository.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
    /// </see>
    public class GitHubContent : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the path of the file.
        /// </summary>
        public string Path { get; }

        /// <summary>
        /// Gets the SHA of the file.
        /// </summary>
        public string Sha { get; }

        /// <summary>
        /// Gets the type of the of the content - eg. <c>file</c>.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the encoding of the file - eg. <c>base64</c>.
        /// </summary>
        public string Encoding { get; }

        /// <summary>
        /// Gets the content of the file.
        /// </summary>
        public string Content { get; }

        #endregion

        #region Constructors

        private GitHubContent(JObject json) : base(json) {
            Name = json.GetString("name");
            Path = json.GetString("path");
            Sha = json.GetString("sha");
            Type = json.GetString("type");
            Encoding = json.GetString("encoding");
            Content = json.GetString("content");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubRepository"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubRepository"/>.</returns>
        public static GitHubContent Parse(JObject json) {
            return json == null ? null : new GitHubContent(json);
        }

        #endregion

    }

}