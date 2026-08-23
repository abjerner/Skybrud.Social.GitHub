using System.Threading.Tasks;
using Skybrud.Social.GitHub.Models.Users;
using Skybrud.Social.GitHub.Options.Users;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.Users.Organizations;

/// <summary>
/// Class representing the <strong>Users / Organizations</strong> endpoint.
/// </summary>
public class GitHubUsersOrganizationsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubUsersOrganizationsRawEndpoint Raw => Service.Client.Users.Organizations;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubUsersOrganizationsEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region GetOrganizations(...)

    /// <summary>
    /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(int userId) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(userId));
    }

    /// <summary>
    /// Gets a list of organizations the user with the specified <paramref name="userId"/> is a member of.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(int userId, int? perPage = null, int? page = null) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(userId, perPage, page));
    }

    /// <summary>
    /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
    /// </summary>
    /// <param name="username">The username (login) of the user.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(string username) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(username));
    }

    /// <summary>
    /// Gets a list of organizations the user with the specified <paramref name="username"/> is a member of.
    /// </summary>
    /// <param name="username">The username (login) of the user.</param>
    /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(string username, int? perPage = null, int? page = null) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(username, perPage, page));
    }

    /// <summary>
    /// Gets a list of organizations the specified <paramref name="user"/> is a member of.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(GitHubUserBase user) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(user));
    }

    /// <summary>
    /// Gets a list of organizations the specified <paramref name="user"/> is a member of.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="perPage">The maximum amount of organizations to returned by each page. Maximum is <c>100</c>.</param>
    /// <param name="page">The page to be returned.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(GitHubUserBase user, int? perPage = null, int? page = null) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(user, perPage, page));
    }

    /// <summary>
    /// Gets a list of organizations the user matching the specified <paramref name="options"/> is a member of.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-a-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(GitHubGetOrganizationsOptions options) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(options));
    }

    #endregion

}