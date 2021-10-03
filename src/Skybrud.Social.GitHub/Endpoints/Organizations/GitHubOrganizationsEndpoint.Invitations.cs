using Skybrud.Social.GitHub.Options.Organizations.Invitations;
using Skybrud.Social.GitHub.Responses.Invites;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {

        /// <summary>
        /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
        public GitHubInvitationListResponse GetPendingInvitations(string orgAlias) {
            return new GitHubInvitationListResponse(Raw.GetPendingInvitations(orgAlias));
        }
        
        /// <summary>
        /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
        /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
        public GitHubInvitationListResponse GetPendingInvitations(string orgAlias, int perPage) {
            return new GitHubInvitationListResponse(Raw.GetPendingInvitations(orgAlias, perPage));
        }
        
        /// <summary>
        /// Returns a list of pending invitation to the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
        public GitHubInvitationListResponse GetPendingInvitations(GitHubGetPendingInvitationsOptions options) {
            return new GitHubInvitationListResponse(Raw.GetPendingInvitations(options));
        }

        /// <summary>
        /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
        public GitHubInvitationListResponse GetFailedInvitations(string orgAlias) {
            return new GitHubInvitationListResponse(Raw.GetFailedInvitations(orgAlias));
        }
        
        /// <summary>
        /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
        /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
        public GitHubInvitationListResponse GetFailedInvitations(string orgAlias, int perPage) {
            return new GitHubInvitationListResponse(Raw.GetFailedInvitations(orgAlias, perPage));
        }
        
        /// <summary>
        /// Returns a list of failed invitation to the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubInvitationListResponse"/> representing the response.</returns>
        public GitHubInvitationListResponse GetFailedInvitations(GitHubGetFailedInvitationsOptions options) {
            return new GitHubInvitationListResponse(Raw.GetFailedInvitations(options));
        }

    }

}