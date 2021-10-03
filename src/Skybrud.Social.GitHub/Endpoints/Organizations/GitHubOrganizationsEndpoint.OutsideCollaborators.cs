using Skybrud.Social.GitHub.Options.Organizations.OutsideCollaborators;
using Skybrud.Social.GitHub.Responses.Users;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(string organization) {
            return new GitHubUserListResponse(Raw.GetOutsideCollaborators(organization));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubUserListResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-organization-members</cref>
        /// </see>
        public GitHubUserListResponse GetOutsideCollaborators(GitHubGetOutsideCollaboratorsOptions options) {
            return new GitHubUserListResponse(Raw.GetOutsideCollaborators(options));
        }

    }

}