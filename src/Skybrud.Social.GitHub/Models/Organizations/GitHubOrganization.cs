using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.GitHub.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations;

/// <summary>
/// Class representing a GitHub organization.
/// </summary>
public class GitHubOrganization : GitHubOrganizationBase {

    #region Properties

    // TODO: which properties are nullable?

    /// <summary>
    /// Gets the name of the organization.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the company name of the organization. This property will likely always be <c>null</c> since the
    /// GitHub website doesn't have a field for specifying the company of an organization.
    /// </summary>
    public string? Company { get; }

    /// <summary>
    /// Gets the blog (website) URL of the organization.
    /// </summary>
    public string? Blog { get; }

    /// <summary>
    /// Gets the location of the organization.
    /// </summary>
    public string? Location { get; }

    /// <summary>
    /// Gets the email address of the organization.
    /// </summary>
    public string? Email { get; }

    /// <summary>
    /// Gets the Twitter username of the organization.
    /// </summary>
    public string? TwitterUsername { get; }

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

    // TODO: add support for the "html_url" property (string)

    // TODO: add support for the "total_private_repos" property (int)

    // TODO: add support for the "owned_private_repos" property (int)

    // TODO: add support for the "private_gists" property (int) (nullable)

    // TODO: add support for the "disk_usage" property (int) (nullable)

    // TODO: add support for the "collaborators" property (int) (nullable)

    // TODO: add support for the "billing_email" property (string) (nullable)

    // TODO: add support for the "plan" property (object)

    // TODO: add support for the "default_repository_permission" property (string) (nullable)

    // TODO: add support for the "default_repository_branch" property (string) (nullable)

    // TODO: add support for the "members_can_create_repositories" property (boolean) (nullable)

    // TODO: add support for the "two_factor_requirement_enabled" property (boolean) (nullable)

    // TODO: add support for the "members_allowed_repository_creation_type" property (string)

    // TODO: add support for the "members_can_create_public_repositories" property (boolean)

    // TODO: add support for the "members_can_create_private_repositories" property (boolean)

    // TODO: add support for the "members_can_create_internal_repositories" property (boolean)

    // TODO: add support for the "members_can_create_pages" property (boolean)

    // TODO: add support for the "members_can_create_public_pages" property (boolean)

    // TODO: add support for the "members_can_create_private_pages" property (boolean)

    // TODO: add support for the "members_can_delete_repositories" property (boolean)

    // TODO: add support for the "members_can_change_repo_visibility" property (boolean)

    // TODO: add support for the "members_can_invite_outside_collaborators" property (boolean)

    // TODO: add support for the "members_can_delete_issues" property (boolean)

    // TODO: add support for the "display_commenter_full_name_setting_enabled" property (boolean)

    // TODO: add support for the "readers_can_create_discussions" property (boolean)

    // TODO: add support for the "members_can_create_teams" property (boolean)

    // TODO: add support for the "members_can_view_dependency_insights" property (boolean)

    // TODO: add support for the "members_can_fork_private_repositories" property (boolean) (nullable)

    // TODO: add support for the "web_commit_signoff_required" property (boolean)

    // TODO: add support for the "advanced_security_enabled_for_new_repositories" property (boolean)

    // TODO: add support for the "dependabot_alerts_enabled_for_new_repositories" property (boolean)

    // TODO: add support for the "dependabot_security_updates_enabled_for_new_repositories" property (boolean)

    // TODO: add support for the "dependency_graph_enabled_for_new_repositories" property (boolean)

    // TODO: add support for the "secret_scanning_enabled_for_new_repositories" property (boolean)

    // TODO: add support for the "secret_scanning_push_protection_enabled_for_new_repositories" property (boolean)

    // TODO: add support for the "secret_scanning_push_protection_custom_link_enabled" property (boolean)

    // TODO: add support for the "secret_scanning_push_protection_custom_link" property (string) (nullable)

    /// <summary>
    /// Gets a timestamp for when the organization was created.
    /// </summary>
    public EssentialsTime CreatedAt { get; }

    /// <summary>
    /// Gets a timestamp for when the organization was last updated.
    /// </summary>
    public EssentialsTime UpdatedAt { get; }

    // TODO: add support for the "archived_at" property (string)

    // TODO: add support for the "deploy_keys_enabled_for_repositories" property (boolean)

    // The API also specifies the property "type", but I'm not sure an organization can be any
    // other type than "Organization", so the property is omitted here for now.

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance from the specified <paramref name="obj"/>.
    /// </summary>
    /// <param name="obj">The instance of <see cref="JObject"/> representing the organization.</param>
    protected GitHubOrganization(JObject obj) : base(obj) {
        Name = obj.GetRequiredString("name");
        Company = obj.GetString("company");
        Blog = obj.GetString("blog");
        Location = obj.GetString("location");
        Email = obj.GetString("email");
        TwitterUsername = obj.GetString("twitter_username");
        IsVerified = obj.GetRequiredBoolean("is_verified");
        HasOrganizationProjects = obj.GetRequiredBoolean("has_organization_projects");
        HasRepositoryProjects = obj.GetRequiredBoolean("has_repository_projects");
        PublicRepos = obj.GetRequiredInt32("public_repos");
        PublicGists = obj.GetRequiredInt32("public_gists");
        Followers = obj.GetRequiredInt32("followers");
        Following = obj.GetRequiredInt32("following");
        // TODO: add support for the "html_url" property (string)
        // TODO: add support for the "total_private_repos" property (int)
        // TODO: add support for the "owned_private_repos" property (int)
        // TODO: add support for the "private_gists" property (int) (nullable)
        // TODO: add support for the "disk_usage" property (int) (nullable)
        // TODO: add support for the "collaborators" property (int) (nullable)
        // TODO: add support for the "billing_email" property (string) (nullable)
        // TODO: add support for the "plan" property (object)
        // TODO: add support for the "default_repository_permission" property (string) (nullable)
        // TODO: add support for the "default_repository_branch" property (string) (nullable)
        // TODO: add support for the "members_can_create_repositories" property (boolean) (nullable)
        // TODO: add support for the "two_factor_requirement_enabled" property (boolean) (nullable)
        // TODO: add support for the "members_allowed_repository_creation_type" property (string)
        // TODO: add support for the "members_can_create_public_repositories" property (boolean)
        // TODO: add support for the "members_can_create_private_repositories" property (boolean)
        // TODO: add support for the "members_can_create_internal_repositories" property (boolean)
        // TODO: add support for the "members_can_create_pages" property (boolean)
        // TODO: add support for the "members_can_create_public_pages" property (boolean)
        // TODO: add support for the "members_can_create_private_pages" property (boolean)
        // TODO: add support for the "members_can_delete_repositories" property (boolean)
        // TODO: add support for the "members_can_change_repo_visibility" property (boolean)
        // TODO: add support for the "members_can_invite_outside_collaborators" property (boolean)
        // TODO: add support for the "members_can_delete_issues" property (boolean)
        // TODO: add support for the "display_commenter_full_name_setting_enabled" property (boolean)
        // TODO: add support for the "readers_can_create_discussions" property (boolean)
        // TODO: add support for the "members_can_create_teams" property (boolean)
        // TODO: add support for the "members_can_view_dependency_insights" property (boolean)
        // TODO: add support for the "members_can_fork_private_repositories" property (boolean) (nullable)
        // TODO: add support for the "web_commit_signoff_required" property (boolean)
        // TODO: add support for the "advanced_security_enabled_for_new_repositories" property (boolean)
        // TODO: add support for the "dependabot_alerts_enabled_for_new_repositories" property (boolean)
        // TODO: add support for the "dependabot_security_updates_enabled_for_new_repositories" property (boolean)
        // TODO: add support for the "dependency_graph_enabled_for_new_repositories" property (boolean)
        // TODO: add support for the "secret_scanning_enabled_for_new_repositories" property (boolean)
        // TODO: add support for the "secret_scanning_push_protection_enabled_for_new_repositories" property (boolean)
        // TODO: add support for the "secret_scanning_push_protection_custom_link_enabled" property (boolean)
        // TODO: add support for the "secret_scanning_push_protection_custom_link" property (string) (nullable)
        CreatedAt = obj.GetRequiredEssentialsTime("created_at");
        UpdatedAt = obj.GetRequiredEssentialsTime("updated_at");
    }

    #endregion

    #region Static methods

    /// <summary>
    /// Parses the specified <paramref name="json"/> object into an instance of <see cref="GitHubOrganization"/>.
    /// </summary>
    /// <param name="json">The instance of <see cref="JObject"/> to be parsed.</param>
    /// <returns>An instance of <see cref="GitHubOrganization"/>.</returns>
    public static new GitHubOrganization Parse(JObject json) {
        return new GitHubOrganization(json);
    }

    #endregion

}