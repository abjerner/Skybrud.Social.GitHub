using System.Threading.Tasks;
using Skybrud.Social.GitHub.Endpoints.Organizations.Invitations;
using Skybrud.Social.GitHub.Endpoints.Organizations.Members;
using Skybrud.Social.GitHub.Endpoints.Organizations.OutsideCollaborators;
using Skybrud.Social.GitHub.Endpoints.Organizations.Repositories;
using Skybrud.Social.GitHub.Endpoints.Organizations.Teams;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.Organizations;

/// <summary>
/// Class representing the <strong>Organizations</strong> endpoint.
/// </summary>
public partial class GitHubOrganizationsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubOrganizationsRawEndpoint Raw => Service.Client.Organizations;

    /// <summary>
    /// Gets a reference to the <strong>Invitations</strong> endpoint.
    /// </summary>
    public GitHubOrganizationInvitationsEndpoint Invitations { get; }

    /// <summary>
    /// Gets a reference to the <strong>Members</strong> endpoint.
    /// </summary>
    public GitHubOrganizationMembersEndpoint Members { get; }

    /// <summary>
    /// Gets a reference to the <strong>Outside Collaborators</strong> endpoint.
    /// </summary>
    public GitHubOrganizationOutsideCollaboratorsEndpoint OutsideCollaborators { get; }

    /// <summary>
    /// Gets a reference to the <strong>Repositories</strong> endpoint.
    /// </summary>
    public GitHubOrganizationRepositoriesEndpoint Repositories { get; }

    /// <summary>
    /// Gets a reference to the <strong>Teams</strong> endpoint.
    /// </summary>
    public GitHubOrganizationTeamsEndpoint Teams { get; }

    #endregion

    #region Constructors

    internal GitHubOrganizationsEndpoint(GitHubHttpService service) {
        Service = service;
        Invitations = new GitHubOrganizationInvitationsEndpoint(service);
        Members = new GitHubOrganizationMembersEndpoint(service);
        OutsideCollaborators = new GitHubOrganizationOutsideCollaboratorsEndpoint(service);
        Repositories = new GitHubOrganizationRepositoriesEndpoint(service);
        Teams = new GitHubOrganizationTeamsEndpoint(service);
    }

    #endregion

    #region GetOrganization(...)

    /// <summary>
    /// Gets information about the organisation with the specified <paramref name="id"/>.
    /// </summary>
    /// <param name="id">The ID of the organization.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationResponse"/> representing the response.</returns>
    public async Task<GitHubOrganizationResponse> GetOrganization(int id) {
        return new GitHubOrganizationResponse(await Raw.GetOrganization(id));
    }

    /// <summary>
    /// Gets information about the organisation with the specified <paramref name="alias"/>.
    /// </summary>
    /// <param name="alias">The alias (login) of the organization.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationResponse"/> representing the response.</returns>
    public async Task<GitHubOrganizationResponse> GetOrganization(string alias) {
        return new GitHubOrganizationResponse(await Raw.GetOrganization(alias));
    }

    #endregion

}