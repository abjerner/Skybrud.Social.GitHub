using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Organizations.Invitations;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsRawEndpoint {

        /// <summary>
        /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPendingInvitations(string orgAlias) {
            if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
            return GetPendingInvitations(new GitHubGetPendingInvitationsOptions(orgAlias));
        }

        /// <summary>
        /// Returns a list of pending invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPendingInvitations(string orgAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
            return GetPendingInvitations(new GitHubGetPendingInvitationsOptions(orgAlias, perPage));
        }

        /// <summary>
        /// Returns a list of pending invitation to the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetPendingInvitations(GitHubGetPendingInvitationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetFailedInvitations(string orgAlias) {
            if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
            return GetFailedInvitations(new GitHubGetFailedInvitationsOptions(orgAlias));
        }

        /// <summary>
        /// Returns a list of failed invitation to the organization with the specified <paramref name="orgAlias"/>.
        /// </summary>
        /// <param name="orgAlias">The alias of the organization.</param>
        /// <param name="perPage">The maximum amount of invites to be returned by each page.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetFailedInvitations(string orgAlias, int perPage) {
            if (string.IsNullOrWhiteSpace(orgAlias)) throw new ArgumentNullException(nameof(orgAlias));
            return GetFailedInvitations(new GitHubGetFailedInvitationsOptions(orgAlias, perPage));
        }

        /// <summary>
        /// Returns a list of failed invitation to the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetFailedInvitations(GitHubGetFailedInvitationsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}