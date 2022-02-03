using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.Members;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(int organizationId) {
            return new GitHubUserListResponse(Raw.GetMembers(organizationId));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(int organizationId, int perPage) {
            return new GitHubUserListResponse(Raw.GetMembers(organizationId, perPage));
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
        public GitHubUserListResponse GetMembers(int organizationId, int perPage, int page) {
            return new GitHubUserListResponse(Raw.GetMembers(organizationId, perPage, page));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(string organizationAlias) {
            return new GitHubUserListResponse(Raw.GetMembers(organizationAlias));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(string organizationAlias, int perPage) {
            return new GitHubUserListResponse(Raw.GetMembers(organizationAlias, perPage));
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
        public GitHubUserListResponse GetMembers(string organizationAlias, int perPage, int page) {
            return new GitHubUserListResponse(Raw.GetMembers(organizationAlias, perPage, page));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(GitHubOrganizationItem organization) {
            return new GitHubUserListResponse(Raw.GetMembers(organization));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(GitHubOrganizationItem organization, int perPage) {
            return new GitHubUserListResponse(Raw.GetMembers(organization, perPage));
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
        public GitHubUserListResponse GetMembers(GitHubOrganizationItem organization, int perPage, int page) {
            return new GitHubUserListResponse(Raw.GetMembers(organization, perPage, page));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetMembers(GitHubGetOrganizationMembersOptions options) {
            return new GitHubUserListResponse(Raw.GetMembers(options));
        }

    }

}