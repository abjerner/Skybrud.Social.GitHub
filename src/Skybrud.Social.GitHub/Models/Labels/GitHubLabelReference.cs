using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Labels {

    /// <summary>
    /// Class representing a GitHub label.
    /// </summary>
    public class GitHubLabelReference : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the name of the label.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the color of the label.
        /// </summary>
        public string Color { get; }

        #endregion

        #region Constructors

        private GitHubLabelReference(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Color = obj.GetString("color");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubLabelReference"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubLabelReference"/>.</returns>
        public static GitHubLabelReference Parse(JObject obj) {
            return obj == null ? null : new GitHubLabelReference(obj);
        }

        #endregion

    }

}