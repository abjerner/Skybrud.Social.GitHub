using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a GitHub organization.
    /// </summary>
    public class GitHubOrganizationItem : GitHubOrganizationBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organization.</param>
        protected GitHubOrganizationItem(JObject json) : base(json) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> into an instance of <see cref="GitHubOrganizationItem"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationItem"/>.</returns>
        public static new GitHubOrganizationItem Parse(JObject json) {
            return new GitHubOrganizationItem(json);
        }

        #endregion

    }

}