using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Organizations.Members;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {
    
    public partial class GitHubOrganizationsRawEndpoint {

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