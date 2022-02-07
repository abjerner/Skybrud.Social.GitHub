using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Repositories.References {

    /// <summary>
    /// Class representing a Git reference.
    /// </summary>
    public class GitHubReference : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the fully qualified name of the reference.
        /// </summary>
        public string Ref { get; }

        /// <summary>
        /// Gets the node ID of the reference.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the API URL of the reference.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets a reference to the ynderlying object of the reference.
        /// </summary>
        public GitHubReferenceObject Object { get; }

        #endregion

        #region Constructors

        private GitHubReference(JObject json) : base(json) {
            Ref = json.GetString("ref");
            NodeId = json.GetString("node_id");
            Url = json.GetString("url");
            Object = json.GetObject("object", GitHubReferenceObject.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubReference"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubReference"/>.</returns>

        public static GitHubReference Parse(JObject json) {
            return json == null ? null : new GitHubReference(json);
        }

        #endregion

    }


}