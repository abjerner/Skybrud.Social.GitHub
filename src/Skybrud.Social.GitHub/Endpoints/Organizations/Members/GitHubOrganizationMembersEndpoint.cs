using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.Members;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations.Members;

/// <summary>
/// Class representing the <strong>Organizations / Members</strong> endpoint.
/// </summary>
public class GitHubOrganizationMembersEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubOrganizationMembersRawEndpoint Raw => Service.Client.Organizations.Members;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubOrganizationMembersEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="organizationId"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(int organizationId) {
        return new GitHubUserListResponse(await Raw.GetMembers(organizationId));
    }

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="organizationId"/>.
    /// </summary>
    /// <param name="organizationId">The ID of the organization.</param>
    /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(int organizationId, int? perPage = null, int? page = null) {
        return new GitHubUserListResponse(await Raw.GetMembers(organizationId, perPage, page));
    }

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
    /// </summary>
    /// <param name="organizationAlias">The alias (username) of the organization.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(string organizationAlias) {
        return new GitHubUserListResponse(await Raw.GetMembers(organizationAlias));
    }

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
    /// </summary>
    /// <param name="organizationAlias">The alias (username) of the organization.</param>
    /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(string organizationAlias, int? perPage = null, int? page = null) {
        return new GitHubUserListResponse(await Raw.GetMembers(organizationAlias, perPage, page));
    }

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The organization.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(GitHubOrganizationItem organization) {
        return new GitHubUserListResponse(await Raw.GetMembers(organization));
    }

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="organization"/>.
    /// </summary>
    /// <param name="organization">The organization.</param>
    /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(GitHubOrganizationItem organization, int? perPage = null, int? page = null) {
        return new GitHubUserListResponse(await Raw.GetMembers(organization, perPage, page));
    }

    /// <summary>
    /// Gets a list of the members of the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
    /// </see>
    public async Task<GitHubUserListResponse> GetMembers(GitHubGetOrganizationMembersOptions options) {
        return new GitHubUserListResponse(await Raw.GetMembers(options));
    }

    #endregion

}