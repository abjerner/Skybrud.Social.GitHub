using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Newtonsoft.Extensions;

namespace Skybrud.Social.GitHub.Models.Organizations;

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
    /// Gets a collection of URLs related to the organization.
    /// </summary>
    public GitHubOrganizationUrls Urls { get; }

    /// <summary>
    /// Gets the avatar URL of the organization.
    /// </summary>
    public string AvatarUrl { get; } // TODO: is this nullable?

    /// <summary>
    /// Gets the description of the organization.
    /// </summary>
    public string? Description { get; } // TODO: is this nullable?

    /// <summary>
    /// Gets whether the organization has a description.
    /// </summary>
    [MemberNotNullWhen(true, nameof(Description))]
    public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

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
        Urls = GitHubOrganizationUrls.Parse(json);
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