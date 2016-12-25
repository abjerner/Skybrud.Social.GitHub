using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Objects.Organizations {

    /// <summary>
    /// Class representing a summary of a GitHub organization.
    /// </summary>
    public class GitHubOrganizationSummary : GitHubObject {

        #region Properties

        /// <summary>
        /// Gets the login (username) of the organization.
        /// </summary>
        public string Login { get; private set; }

        /// <summary>
        /// Gets the ID of the organization.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Gets a collection of URLs related to the organization.
        /// </summary>
        public GitHubOrganizationUrlCollection Urls { get; private set; }

        /// <summary>
        /// Gets the avatar URL of the organization.
        /// </summary>
        public string AvatarUrl { get; private set; }

        #endregion

        #region Constructor

        private GitHubOrganizationSummary(JObject obj) : base(obj) {
            Login = obj.GetString("login");
            Id = obj.GetInt32("id");
            Urls = GitHubOrganizationUrlCollection.Parse(obj);
            AvatarUrl = obj.GetString("avatar_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>obj</code> into an instance of <code>GitHubOrganizationSummary</code>.
        /// </summary>
        /// <param name="obj">The instance of <code>JObject</code> to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubOrganizationSummary</code>.</returns>
        public static GitHubOrganizationSummary Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganizationSummary(obj);
        }

        #endregion

    }

}