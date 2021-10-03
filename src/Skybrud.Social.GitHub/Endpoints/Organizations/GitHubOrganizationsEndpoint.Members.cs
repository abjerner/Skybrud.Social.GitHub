using Skybrud.Social.GitHub.Options.Organizations.Members;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

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