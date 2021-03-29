using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.GitHub.Extensions;
using Skybrud.Social.GitHub.Models.Common;

namespace Skybrud.Social.GitHub.Models.Teams {

    /// <summary>
    /// Class representing a GitHub team.
    /// </summary>
    public class GitHubTeamItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the name of the team.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the ID of the team.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the node ID of the team.
        /// </summary>
        public string NodeId { get; }

        /// <summary>
        /// Gets the slug of the team.
        /// </summary>
        public string Slug { get; }

        /// <summary>
        /// Gets the description of the team.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets the privacy setting of the team.
        /// </summary>
        public GitHubTeamPrivacy Privacy { get; }

        /// <summary>
        /// Gets the default permission of the team.
        /// </summary>
        public GitHubPermissionLevel Permission { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the team.</param>
        protected GitHubTeamItem(JObject json) : base(json) {
            Name = json.GetString("name");
            Id = json.GetInt32("id");
            NodeId = json.GetString("node_id");
            Slug = json.GetString("slug");
            Description = json.GetString("description");
            Privacy = json.GetEnumWithFallbacks<GitHubTeamPrivacy>("privacy");
            // TODO: Add support for the "url" property
            // TODO: Add support for the "html_url" property
            // TODO: Add support for the "members_url" property
            // TODO: Add support for the "repositories_url" property
            // TODO: Add support for the "url" property
            Permission = json.GetEnumWithFallbacks<GitHubPermissionLevel>("permission");
            // TODO: Add support for the "parent" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubTeamItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubTeamItem"/>.</returns>
        public static GitHubTeamItem Parse(JObject json) {
            return json == null ? null : new GitHubTeamItem(json);
        }

        #endregion

    }

}