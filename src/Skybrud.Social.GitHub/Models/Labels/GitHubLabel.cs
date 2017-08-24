using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Labels {

    /// <summary>
    /// Class representing a GitHub label.
    /// </summary>
    public class GitHubLabel : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the label.
        /// </summary>
        public long Id { get; private set; }

        /// <summary>
        /// Gets the API URL of the label.
        /// </summary>
        public string Url { get; private set; }

        /// <summary>
        /// Gets the name of the label.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the color of the label.
        /// </summary>
        public string Color { get; private set; }

        /// <summary>
        /// Gets this is a default label.
        /// </summary>
        public bool IsDefault { get; private set; }

        #endregion

        #region Constructor

        private GitHubLabel(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Url = obj.GetString("url");
            Name = obj.GetString("name");
            Color = obj.GetString("color");
            IsDefault = obj.GetBoolean("default");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubLabel"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubLabel"/>.</returns>
        public static GitHubLabel Parse(JObject obj) {
            return obj == null ? null : new GitHubLabel(obj);
        }

        #endregion

    }

}