using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub organization.
    /// </summary>
    public class GitHubOrganizationUrls {

        #region Properties
        
        /// <summary>
        /// Gets the API URL of the organization.
        /// </summary>
        public string Url { get; }
        
        /// <summary>
        /// Gets the API URL for getting a list of repositories of the organization.
        /// </summary>
        public string ReposUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of events made by members of the organization.
        /// </summary>
        public string EventsUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of hooks of the organization.
        /// </summary>
        public string HooksUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of issues of the organization.
        /// </summary>
        public string IssuesUrl { get; }

        /// <summary>
        /// Gets the API URL for getting a list of members of the organization.
        /// </summary>
        public string MembersUrl { get; }
        
        /// <summary>
        /// Gets the API URL for getting a list of public members of the organization.
        /// </summary>
        public string PublicMembersUrl { get; }

        /// <summary>
        /// Gets the website (HTML) URL of the organization.
        /// </summary>
        public string HtmlUrl { get; }

        #endregion

        #region Constructors

        private GitHubOrganizationUrls(JObject obj) {
            Url = obj.GetString("url");
            ReposUrl = obj.GetString("repos_url");
            EventsUrl = obj.GetString("events_url");
            HooksUrl = obj.GetString("hooks_url");
            IssuesUrl = obj.GetString("issues_url");
            MembersUrl = obj.GetString("members_url");
            PublicMembersUrl = obj.GetString("public_members_url");
            HtmlUrl = obj.GetString("html_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganizationUrls"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationUrls"/>.</returns>
        public static GitHubOrganizationUrls Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganizationUrls(obj);
        }

        #endregion

    }

}