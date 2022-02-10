using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations {

    /// <summary>
    /// Class representing a GitHub organization.
    /// </summary>
    public class GitHubOrganization : GitHubOrganizationBase {

        #region Properties

        /// <summary>
        /// Gets the name of the organization.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the company name of the organization. This property will likely always be <c>null</c> since the
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
        /// Gets the Twitter username of the organization.
        /// </summary>
        public string TwitterUsername { get; }

        /// <summary>
        /// Gets whether the organization is verified.
        /// </summary>
        public bool IsVerified { get; }

        /// <summary>
        /// Gets whether the organization has any projects at the organization level.
        /// </summary>
        public bool HasOrganizationProjects { get; }

        /// <summary>
        /// Gets whether the organization has any projects at the repository level.
        /// </summary>
        public bool HasRepositoryProjects { get; }

        /// <summary>
        /// Gets the amount of public repositories of the organization.
        /// </summary>
        public int PublicRepos { get; }

        /// <summary>
        /// Gets the amount of public gists of the organization. This property will likely always be <c>0</c>
        /// since an organization won't be able to create any gists.
        /// </summary>
        public int PublicGists { get; }

        /// <summary>
        /// Gets the amount of followers of the organization. This property will most likely always return
        /// <c>0</c> since the GitHub website doesn't allow a user to follow an organization.
        /// </summary>
        public int Followers { get; }

        /// <summary>
        /// Gets the amount of users the organization is following. This property will most likely always return
        /// <c>0</c> since the GitHub website doesn't allow an organization to follow a user.
        /// </summary>
        public int Following { get; }

        /// <summary>
        /// Gets a timestamp for when the organization was created.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets a timestamp for when the organization was last updated.
        /// </summary>
        public EssentialsTime UpdatedAt { get; }

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
            TwitterUsername = obj.GetString("twitter_username");
            IsVerified = obj.GetBoolean("is_verified");
            HasOrganizationProjects = obj.GetBoolean("has_organization_projects");
            HasRepositoryProjects = obj.GetBoolean("has_repository_projects");
            PublicRepos = obj.GetInt32("public_repos");
            PublicGists = obj.GetInt32("public_gists");
            Followers = obj.GetInt32("followers");
            Following = obj.GetInt32("following");
            CreatedAt = obj.GetEssentialsTime("created_at");
            UpdatedAt = obj.GetEssentialsTime("updated_at");
            // Add support for the "total_private_repos" property
            // Add support for the "owned_private_repos" property
            // Add support for the "private_gists" property
            // Add support for the "disk_usage" property
            // Add support for the "collaborators" property
            // Add support for the "billing_email" property
            // Add support for the "plan" property
            // Add support for the "default_repository_permission" property
            // Add support for the "members_can_create_repositories" property
            // Add support for the "two_factor_requirement_enabled" property
            // Add support for the "members_can_create_pages" property
            // Add support for the "members_can_create_public_pages" property
            // Add support for the "members_can_create_private_pages" property
            // Add support for the "plan" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="GitHubOrganization"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubOrganization"/>.</returns>
        public static new GitHubOrganization Parse(JObject obj) {
            return obj == null ? null : new GitHubOrganization(obj);
        }

        #endregion

    }

}