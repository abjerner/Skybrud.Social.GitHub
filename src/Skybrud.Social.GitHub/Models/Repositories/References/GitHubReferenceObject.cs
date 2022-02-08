using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Repositories.References {

    /// <summary>
    /// Class representing a Git reference object.
    /// </summary>
    public class GitHubReferenceObject : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the SHA1 hash of the object.
        /// </summary>
        public string Sha { get; }

        /// <summary>
        /// Gets the type of the object.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Gets the API URL of the object.
        /// </summary>
        public string Url { get; }

        #endregion

        #region Constructors

        private GitHubReferenceObject(JObject json) : base(json) {
            Sha = json.GetString("sha");
            Type = json.GetString("type");
            Url = json.GetString("url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubReferenceObject"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReferenceObject"/>.</returns>
        public static GitHubReferenceObject Parse(JObject json) {
            return json == null ? null : new GitHubReferenceObject(json);
        }

        #endregion

    }

}