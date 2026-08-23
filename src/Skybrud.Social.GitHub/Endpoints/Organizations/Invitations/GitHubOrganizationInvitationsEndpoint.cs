using System.Threading.Tasks;
using Skybrud.Social.GitHub.Options.Organizations.Invitations;
using Skybrud.Social.GitHub.Responses.Invites;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.Invitations;

/// <summary>
/// Class representing the <strong>Organizations / Invitations</strong> endpoint.
/// </summary>
public class GitHubOrganizationInvitationsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubOrganizationInvitationsRawEndpoint Raw => Service.Client.Organizations.Invitations;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubOrganizationInvitationsEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
    public async Task<GitHubInvitationListResponse> GetPendingInvitations(string orgAlias) {
        return new GitHubInvitationListResponse(await Raw.GetPendingInvitations(orgAlias));
    }

    /// <summary>
    /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
    public async Task<GitHubInvitationListResponse> GetPendingInvitations(string orgAlias, int? perPage = null, int? page = null) {
        return new GitHubInvitationListResponse(await Raw.GetPendingInvitations(orgAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of pending invitation to the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
    public async Task<GitHubInvitationListResponse> GetPendingInvitations(GitHubGetPendingInvitationsOptions options) {
        return new GitHubInvitationListResponse(await Raw.GetPendingInvitations(options));
    }

    /// <summary>
    /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
    public async Task<GitHubInvitationListResponse> GetFailedInvitations(string orgAlias) {
        return new GitHubInvitationListResponse(await Raw.GetFailedInvitations(orgAlias));
    }

    /// <summary>
    /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
    public async Task<GitHubInvitationListResponse> GetFailedInvitations(string orgAlias, int? perPage = null, int? page = null) {
        return new GitHubInvitationListResponse(await Raw.GetFailedInvitations(orgAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of failed invitation to the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
    public async Task<GitHubInvitationListResponse> GetFailedInvitations(GitHubGetFailedInvitationsOptions options) {
        return new GitHubInvitationListResponse(await Raw.GetFailedInvitations(options));
    }

    #endregion

}