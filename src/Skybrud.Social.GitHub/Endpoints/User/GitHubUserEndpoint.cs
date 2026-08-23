using System.Threading.Tasks;
using Skybrud.Social.GitHub.Endpoints.User.Organizations;
using Skybrud.Social.GitHub.Endpoints.User.Repositories;
using Skybrud.Social.GitHub.Responses.Emails;
using Skybrud.Social.GitHub.Responses.Followers;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.User;

/// <summary>
/// Class representing the <strong>User</strong> endpoint.
/// </summary>
public class GitHubUserEndpoint {

    #region Properties

    /// <summary>
    /// Gets a reference to the GitHub service.
    /// </summary>
    public GitHubHttpService Service { get; }

    /// <summary>
    /// Gets a reference to the raw endpoint.
    /// </summary>
    public GitHubUserRawEndpoint Raw => Service.Client.User;

    /// <summary>
    /// Gets a reference to the <strong>Organizations</strong> endpoint.
    /// </summary>
    public GitHubUserOrganizationsEndpoint Organizations { get; }

    /// <summary>
    /// Gets a reference to the <strong>Repositories</strong> endpoint.
    /// </summary>
    public GitHubUserRepositoriesEndpoint Repositories { get; }

    #endregion

    #region Constructors

    internal GitHubUserEndpoint(GitHubHttpService service) {
        Service = service;
        Organizations = new GitHubUserOrganizationsEndpoint(service);
        Repositories = new GitHubUserRepositoriesEndpoint(service);
    }

    #endregion

    #region Member methods

    /// <summary>
    /// Gets information about the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="GitHubUserResponse"/> representing the response.</returns>
    public async Task<GitHubUserResponse> GetUser() {
        return new GitHubUserResponse(await Raw.GetUser());
    }

    /// <summary>
    /// Gets a list of email addresses of the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="GitHubEmailListResponse"/> representing the response.</returns>
    public async Task<GitHubEmailListResponse> GetEmails() {
        return new GitHubEmailListResponse(await Raw.GetEmails());
    }

    /// <summary>
    /// Gets a list of users following the authenticated user.
    /// </summary>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    public async Task<GitHubUserListResponse> GetFollowers() {
        return new GitHubUserListResponse(await Raw.GetFollowers());
    }

    /// <summary>
    /// Gets a list of users the authenticated user is following.
    /// </summary>
    /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
    public async Task<GitHubUserListResponse> GetFollowing() {
        return new GitHubUserListResponse(await Raw.GetFollowing());
    }

    /// <summary>
    /// Gets whether the authenticated user is following the user with the specified <paramref name="username"/>.
    /// </summary>
    /// <param name="username">The username (login) of the user.</param>
    /// <returns>An instance of <see cref="GitHubGetFollowingResponse"/> representing the response.</returns>
    public async Task<GitHubGetFollowingResponse> IsFollowing(string username) {
        return new GitHubGetFollowingResponse(await Raw.IsFollowing(username));
    }

    #endregion

}