using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a GitHub organization.
    /// </summary>
    public class GitHubOrganization : GitHubOrganizationItem {

        #region Properties

        /// <summary>
        /// Gets the name of the organization.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the company name of the organization. This property will likely always be <code>null</code> since the
        /// GitHub website doesn't have a field for specifying the company of an organization.
        /// </summary>
        public string Company { get; }

        /// <summary>
        /// Gets the blog (website) URL of the organization.
        /// </summary>
        public string Blog { get; }

        /// <summary>
        /// Gets the location of the organization.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Gets the email address of the organization.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the amount of public repositories of the organization.
        /// </summary>
        public int PublicRepos { get; }

        /// <summary>
        /// Gets the amount of public gists of the organization. This property will likely always be <code>0</code>
        /// since an organization won't be able to create any gists.
        /// </summary>
        public int PublicGists { get; }

        /// <summary>
        /// Gets the amount of followers of the organization. This property will most likely always return
        /// <code>0</code> since the GitHub website doesn't allow a user to follow an organization.
        /// </summary>
        public int Followers { get; }

        /// <summary>
        /// Gets the amount of users the organization is following. This property will most likely always return
        /// <code>0</code> since the GitHub website doesn't allow an organization to follow a user.
        /// </summary>
        public int Following { get; }

        /// <summary>
        /// Gets a timestamp for when the organization was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the organization was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; }

        // The API also specifies the property "type", but I'm not sure an organization can be any
        // other type than "Organization", so the property is omitted here for now.

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the organization.</param>
        protected GitHubOrganization(JObject obj) : base(obj) {
            Name = obj.GetString("name");
            Company = obj.GetString("company");
            Blog = obj.GetString("blog");
            Location = obj.GetString("location");
            Email = obj.GetString("email");
            // Add support for the "has_organization_projects" property
            // Add support for the "has_repository_projects" property
            PublicRepos = obj.GetInt32("public_repos");
            PublicGists = obj.GetInt32("public_gists");
            Followers = obj.GetInt32("followers");
            Following = obj.GetInt32("following");
            CreatedAt = obj.GetDateTime("created_at");
            UpdatedAt = obj.GetDateTime("updated_at");
            // Add support for the "total_private_repos" property
            // Add support for the "owned_private_repos" property
            // Add support for the "private_gists" property
            // Add support for the "disk_usage" property
            // Add support for the "collaborators" property
            // Add support for the "billing_email" property
            // Add support for the "plan" property
            // Add support for the "default_repository_permission" property
            // Add support for the "members_can_create_repositories" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganization"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganization"/>.</returns>
        public new static GitHubOrganization Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganization(obj);
        }

        #endregion

    }

}
