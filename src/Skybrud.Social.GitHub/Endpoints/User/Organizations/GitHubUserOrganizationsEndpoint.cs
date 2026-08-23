using System.Threading.Tasks;
using Skybrud.Social.GitHub.Options.User.Organizations;
using Skybrud.Social.GitHub.Responses.Organizations;

namespace Skybrud.Social.GitHub.Endpoints.User.Organizations;

/// <summary>
/// Class representing the <strong>User / Organizations</strong> endpoint.
/// </summary>
public class GitHubUserOrganizationsEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubUserOrganizationsRawEndpoint Raw => Service.Client.User.Organizations;

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance based on the specified <paramref name="service"/>.
    /// </summary>
    /// <param name="service">The HTTP service instance.</param>
    public GitHubUserOrganizationsEndpoint(GitHubHttpService service) {
        Service = service;
    }

    #endregion

    #region GetOrganizations(...)

    /// <summary>
    /// Gets a list of organizations the authenticated user is a member of.
    /// </summary>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations() {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations());
    }

    /// <summary>
    /// Returns a list of organizations the authenticated user is a member of.
    /// </summary>
    /// <param name="options">The options for the request to the API.</param>
    /// <returns>An instance of <see cref="GitHubOrganizationListResponse"/> representing the response.</returns>
    /// <see>
    ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organizations-for-the-authenticated-user</cref>
    /// </see>
    public async Task<GitHubOrganizationListResponse> GetOrganizations(GitHubGetOrganizationsOptions options) {
        return new GitHubOrganizationListResponse(await Raw.GetOrganizations(options));
    }

    #endregion

}