using Newtonsoft.Json.Linq;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a GitHub organization.
    /// </summary>
    public class GitHubOrganizationItem : GitHubOrganizationBase {

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the organizationt.</param>
        protected GitHubOrganizationItem(JObject obj) : base(obj) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganizationItem"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationItem"/>.</returns>
        public static new GitHubOrganizationItem Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganizationItem(obj);
        }

        #endregion

    }

}