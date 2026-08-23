using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Endpoints.Organizations.Invitations;
using Skybrud.Social.GitHub.Endpoints.Organizations.Members;
using Skybrud.Social.GitHub.Endpoints.Organizations.OutsideCollaborators;
using Skybrud.Social.GitHub.Endpoints.Organizations.Repositories;
using Skybrud.Social.GitHub.Endpoints.Organizations.Teams;
using Skybrud.Social.GitHub.OAuth;

namespace Skybrud.Social.GitHub.Endpoints.Organizations;

/// <summary>
/// Class representing the raw <strong>Organizations</strong> endpoint.
/// </summary>
/// <see>
///     <cref>https://developer.github.com/v3/orgs/</cref>
/// </see>
public class GitHubOrganizationsRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    /// <summary>
    /// Gets a reference to the <strong>Invitations</strong> endpoint.
    /// </summary>
    public GitHubOrganizationInvitationsRawEndpoint Invitations { get; }

    /// <summary>
    /// Gets a reference to the <strong>Members</strong> endpoint.
    /// </summary>
    public GitHubOrganizationMembersRawEndpoint Members { get; }

    /// <summary>
    /// Gets a reference to the <strong>Outside Collaborators</strong> endpoint.
    /// </summary>
    public GitHubOrganizationOutsideCollaboratorsRawEndpoint OutsideCollaborators { get; }

    /// <summary>
    /// Gets a reference to the <strong>Repositories</strong> endpoint.
    /// </summary>
    public GitHubOrganizationRepositoriesRawEndpoint Repositories { get; }

    /// <summary>
    /// Gets a reference to the <strong>Teams</strong> endpoint.
    /// </summary>
    public GitHubOrganizationTeamsRawEndpoint Teams { get; }

    #endregion

    #region Constructors

    internal GitHubOrganizationsRawEndpoint(GitHubOAuthClient client) {
        Client = client;
        Invitations = new GitHubOrganizationInvitationsRawEndpoint(client);
        Members = new GitHubOrganizationMembersRawEndpoint(client);
        OutsideCollaborators = new GitHubOrganizationOutsideCollaboratorsRawEndpoint(client);
        Repositories = new GitHubOrganizationRepositoriesRawEndpoint(client);
        Teams = new GitHubOrganizationTeamsRawEndpoint(client);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Gets information about the organisation with the specified <paramref name="organizationId"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetOrganization(int organizationId) {
        return await Client.GetAsync($"/organizations/{organizationId}");
    }

    /// <summary>
    /// Gets information about the organisation with the specified <paramref name="organizationAlias"/>.
    /// </summary>
    /// <param name="organizationAlias">The alias (login) of the organization.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetOrganization(string organizationAlias) {
        if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
        return await Client.GetAsync($"/orgs/{organizationAlias}");
    }

    #endregion

}