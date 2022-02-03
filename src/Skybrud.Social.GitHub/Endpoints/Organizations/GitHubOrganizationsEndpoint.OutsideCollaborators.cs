using System;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.OutsideCollaborators;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(int organizationId) {
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationId));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(int organizationId, int perPage) {
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationId, perPage));
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
        public GitHubUserListResponse GetOutsideCollaborators(int organizationId, int perPage, int page) {
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationId, perPage, page));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(string organization) {
            return new GitHubUserListResponse(Raw.GetOutsideCollaborators(organization));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(string organizationAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationAlias, perPage));
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
        public GitHubUserListResponse GetOutsideCollaborators(string organizationAlias, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organizationAlias, perPage, page));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(GitHubOrganizationItem organization) {
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organization));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The maximum amount of collaborators to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(GitHubOrganizationItem organization, int perPage) {
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organization, perPage));
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
        public GitHubUserListResponse GetOutsideCollaborators(GitHubOrganizationItem organization, int perPage, int page) {
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organization, perPage, page));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(GitHubGetOutsideCollaboratorsOptions options) {
            return new GitHubUserListResponse(Raw.GetOutsideCollaborators(options));
        }

    }

}