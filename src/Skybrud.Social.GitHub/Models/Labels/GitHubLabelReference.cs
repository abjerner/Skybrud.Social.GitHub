using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

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

        private GitHubLabelReference(JObject json) : base(json) {
            Name = json.GetRequiredString("name");
            Color = json.GetRequiredString("color");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubLabelReference"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubLabelReference"/>.</returns>
        public static GitHubLabelReference Parse(JObject json) {
            return new GitHubLabelReference(json);
        }

        #endregion

    }

}