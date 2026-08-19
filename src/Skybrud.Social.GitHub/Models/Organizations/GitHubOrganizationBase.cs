using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a GitHub organization.
    /// </summary>
    public class GitHubOrganizationBase : GitHubObject {

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
        /// Gets the node ID of the organization.
        /// </summary>
        public string NodeId { get; }

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
        /// Gets the avatar URL of the organization.
        /// </summary>
        public string AvatarUrl { get; }

        /// <summary>
        /// Gets the description of the organization.
        /// </summary>
        public string? Description { get; }

        /// <summary>
        /// Gets whether the organization has a description.
        /// </summary>
        [MemberNotNullWhen(true, nameof(Description))]
        public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

        // TODO: no "html_url" property???

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> representing the organization.</param>
        protected GitHubOrganizationBase(JObject json) : base(json) {
            Login = json.GetRequiredString("login");
            Id = json.GetRequiredInt32("id");
            NodeId = json.GetRequiredString("node_id");
            Url = json.GetRequiredString("url");
            ReposUrl = json.GetRequiredString("repos_url");
            EventsUrl = json.GetRequiredString("events_url");
            HooksUrl = json.GetRequiredString("hooks_url");
            IssuesUrl = json.GetRequiredString("issues_url");
            MembersUrl = json.GetRequiredString("members_url");
            PublicMembersUrl = json.GetRequiredString("public_members_url");
            AvatarUrl = json.GetRequiredString("avatar_url");
            Description = json.GetString("description");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubOrganizationBase"/>.
        /// </summary>
        /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganizationBase"/>.</returns>
        public static GitHubOrganizationBase Parse(JObject json) {
            return new GitHubOrganizationBase(json);
        }

        #endregion

    }

}