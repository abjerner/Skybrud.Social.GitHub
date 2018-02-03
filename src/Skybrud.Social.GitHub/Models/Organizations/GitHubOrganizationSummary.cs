using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a summary of a GitHub organization.
    /// </summary>
    public class GitHubOrganizationSummary : GitHubObject {

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
        public GitHubOrganizationUrlCollection Urls { get; }

        /// <summary>
        /// Gets the avatar URL of the organization.
        /// </summary>
        public string AvatarUrl { get; }

        #endregion

        #region Constructors

        private GitHubOrganizationSummary(JObject obj) : base(obj) {
            Login = obj.GetString("login");
            Id = obj.GetInt32("id");
            Urls = GitHubOrganizationUrlCollection.Parse(obj);
            AvatarUrl = obj.GetString("avatar_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganizationSummary"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationSummary"/>.</returns>
        public static GitHubOrganizationSummary Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganizationSummary(obj);
        }

        #endregion

    }

}