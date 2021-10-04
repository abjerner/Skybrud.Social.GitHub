using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Invitations;

namespace Skybrud.Social.GitHub.Responses.Invites {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubInvitationItem"/>.
    /// </summary>
    public class GitHubInvitationListResponse : GitHubListResponse<GitHubInvitationItem> {

        /// <summary>
        /// Initializes a new instance based on the specified raw <paramref name="response"/> response.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        public GitHubInvitationListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubInvitationItem.Parse);
        }

    }

}