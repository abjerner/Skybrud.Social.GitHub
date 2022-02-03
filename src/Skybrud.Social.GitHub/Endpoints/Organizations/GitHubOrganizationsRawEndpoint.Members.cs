using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.GitHub.Options.Organizations.Members;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsRawEndpoint {

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(int organizationId) {
            return GetMembers(new GitHubGetOrganizationMembersOptions(organizationId));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(int organizationId, int perPage) {
            return GetMembers(new GitHubGetOrganizationMembersOptions(organizationId, perPage, default));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationId"/>.
        /// </summary>
        /// <param name="organizationId">The ID of the organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(int organizationId, int perPage, int page) {
            return GetMembers(new GitHubGetOrganizationMembersOptions(organizationId, perPage, page));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(string organizationAlias) {
            if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
            return GetMembers(new GitHubGetOrganizationMembersOptions(organizationAlias));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(string organizationAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
            return GetMembers(new GitHubGetOrganizationMembersOptions(organizationAlias, perPage));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organizationAlias"/>.
        /// </summary>
        /// <param name="organizationAlias">The alias (username) of the organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(string organizationAlias, int perPage, int page) {
            if (string.IsNullOrWhiteSpace(organizationAlias)) throw new ArgumentNullException(nameof(organizationAlias));
            return GetMembers(new GitHubGetOrganizationMembersOptions(organizationAlias, perPage, page));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(GitHubOrganizationItem organization) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            return GetMembers(new GitHubGetOrganizationMembersOptions(organization));
        }
        
        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(GitHubOrganizationItem organization, int perPage) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            return GetMembers(new GitHubGetOrganizationMembersOptions(organization, perPage));
        }
        
        /// <summary>
        /// Gets a list of the members of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The organization.</param>
        /// <param name="perPage">The maximum amount of members to returned by each page. Maximum is <c>100</c>.</param>
        /// <param name="page">The page to be returned.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(GitHubOrganizationItem organization, int perPage, int page) {
            if (organization == null) throw new ArgumentNullException(nameof(organization));
            return GetMembers(new GitHubGetOrganizationMembersOptions(organization, perPage, page));
        }

        /// <summary>
        /// Gets a list of the members of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public IHttpResponse GetMembers(GitHubGetOrganizationMembersOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}