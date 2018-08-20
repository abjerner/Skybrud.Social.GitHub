using System;
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
        public long Id { get; }

        /// <summary>
        /// Gets the node ID of the label.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the API URL of the label.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the name of the label.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the description of the label.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the label has a description.
        /// </summary>
        public bool HasDescription => !String.IsNullOrWhiteSpace(Description);

        /// <summary>
        /// Gets the color of the label.
        /// </summary>
        public string Color { get; }

        /// <summary>
        /// Gets this is a default label.
        /// </summary>
        public bool IsDefault { get; }

        #endregion

        #region Constructors

        private GitHubLabel(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            NodeId = obj.GetString("node_id");
            Url = obj.GetString("url");
            Name = obj.GetString("name");
            Description = obj.GetString("description");
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