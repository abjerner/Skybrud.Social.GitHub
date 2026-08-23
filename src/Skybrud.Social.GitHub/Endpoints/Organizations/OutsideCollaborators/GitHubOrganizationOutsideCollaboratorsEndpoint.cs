using System;
using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.OutsideCollaborators;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.OutsideCollaborators;

/// <summary>
/// Class representing the <strong>Organizations / Outside Collaborators</strong> endpoint.
/// </summary>
public class GitHubOrganizationOutsideCollaboratorsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubOrganizationOutsideCollaboratorsRawEndpoint Raw => Service.Client.Organizations.OutsideCollaborators;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubOrganizationOutsideCollaboratorsEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="organizationId"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(int organizationId) {
        return await GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationId));
    }

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="organizationId"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(int organizationId, int? perPage = null, int? page = null) {
        return await GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationId, perPage, page));
    }

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The alias (username) of the organization.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(string organization) {
        return new GitHubUserListResponse(await Raw.GetOutsideCollaborators(organization));
    }

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="organizationAlias"/>.
    /// </summary>
    /// <param name="organizationAlias">The alias (username) of the organization.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(string organizationAlias, int? perPage = null, int? page = null) {
        if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
        return await GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationAlias, perPage, page));
    }

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The organization.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(GitHubOrganizationItem organization) {
        return await GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organization));
    }

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The organization.</param>
    /// <param name="perPage">The maximum amount of collaborators to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(GitHubOrganizationItem organization, int? perPage = null, int? page = null) {
        return await GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organization, perPage, page));
    }

    /// <summary>
    /// Gets a list of the outside collaborators of the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetOutsideCollaborators(GitHubGetOutsideCollaboratorsOptions options) {
        return new GitHubUserListResponse(await Raw.GetOutsideCollaborators(options));
    }

    #endregion

}