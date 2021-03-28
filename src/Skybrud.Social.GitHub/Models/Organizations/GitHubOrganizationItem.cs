using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a GitHub organization.
    /// </summary>
    public class GitHubOrganizationItem : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the login (username) of the organization.
        /// </summary>
        public string Login { get; }

        /// <summary>
        /// Gets the ID of the organization.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets a collection of URLs related to the organization.
        /// </summary>
        public GitHubOrganizationUrls Urls { get; }

        /// <summary>
        /// Gets the avatar URL of the organization.
        /// </summary>
        public string AvatarUrl { get; }

        /// <summary>
        /// Gets the description of the organization.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the organization has a description.
        /// </summary>
        public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubOrganizationItem(JObject obj) : base(obj) {
            Login = obj.GetString("login");
            Id = obj.GetInt32("id");
            Urls = GitHubOrganizationUrls.Parse(obj);
            AvatarUrl = obj.GetString("avatar_url");
            Description = obj.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganizationItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationItem"/>.</returns>
        public static GitHubOrganizationItem Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganizationItem(obj);
        }

        #endregion

    }

}