using System;
using System.Threading.Tasks;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.OAuth;
using Skybrud.Social.GitHub.Options.Organizations.Invitations;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.Invitations;

/// <summary>
/// Class representing the raw <strong>Organization / Invitations</strong> endpoint.
/// </summary>
public class GitHubOrganizationInvitationsRawEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the parent OAuth client.
    /// </summary>
    public GitHubOAuthClient Client { get; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="client"/>.
    /// </summary>
    /// <param name="client">The OAuth instance.</param>
    public GitHubOrganizationInvitationsRawEndpoint(GitHubOAuthClient client) {
        Client = client;
    }

    #endregion

    /// <summary>
    /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetPendingInvitations(string orgAlias) {
        if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
        return await GetPendingInvitations(new GitHubGetPendingInvitationsOptions(orgAlias));
    }

    /// <summary>
    /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetPendingInvitations(string orgAlias, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
        return await GetPendingInvitations(new GitHubGetPendingInvitationsOptions(orgAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of pending invitation to the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetPendingInvitations(GitHubGetPendingInvitationsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

    /// <summary>
    /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetFailedInvitations(string orgAlias) {
        if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
        return await GetFailedInvitations(new GitHubGetFailedInvitationsOptions(orgAlias));
    }

    /// <summary>
    /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
    /// </summary>
    /// <param name="orgAlias">The alias of the organization.</param>
    /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetFailedInvitations(string orgAlias, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
        return await GetFailedInvitations(new GitHubGetFailedInvitationsOptions(orgAlias, perPage, page));
    }

    /// <summary>
    /// Returns a list of failed invitation to the organization matching the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
    public async Task<IHttpResponse> GetFailedInvitations(GitHubGetFailedInvitationsOptions options) {
        if (options == null) throw new ArgumentNullException(nameof(options));
        return await Client.GetResponseAsync(options);
    }

}