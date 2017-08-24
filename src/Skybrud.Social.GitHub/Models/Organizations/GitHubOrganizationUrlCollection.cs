using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a collection of URLs related to a GitHub organization.
    /// </summary>
    public class GitHubOrganizationUrlCollection {

        #region Properties
        
        /// <summary>
        /// Gets the API URL of the organization.
        /// </summary>
        public string Url { get; private set; }
        
        /// <summary>
        /// Gets the API URL for getting a list of repositories of the organization.
        /// </summary>
        public string ReposUrl { get; private set; }
        
        /// <summary>
        /// Gets the API URL for getting a list of events made by members of the organization.
        /// </summary>
        public string EventsUrl { get; private set; }

        /// <summary>
        /// Gets the API URL for getting a list of members of the organization.
        /// </summary>
        public string MembersUrl { get; private set; }
        
        /// <summary>
        /// Gets the API URL for getting a list of public members of the organization.
        /// </summary>
        public string PublicMembersUrl { get; private set; }

        /// <summary>
        /// Gets the website (HTML) URL of the organization.
        /// </summary>
        public string HtmlUrl { get; private set; }

        #endregion

        #region Constructor

        private GitHubOrganizationUrlCollection(JObject obj) {
            Url = obj.GetString("url");
            ReposUrl = obj.GetString("repos_url");
            EventsUrl = obj.GetString("events_url");
            MembersUrl = obj.GetString("members_url");
            PublicMembersUrl = obj.GetString("public_members_url");
            HtmlUrl = obj.GetString("html_url");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganizationUrlCollection"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>Returns an instance of <see cref="GitHubOrganizationUrlCollection"/>.</returns>
        public static GitHubOrganizationUrlCollection Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganizationUrlCollection(obj);
        }

        #endregion

    }

}