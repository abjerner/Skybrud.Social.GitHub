using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubOrganizationItem"/>.
    /// </summary>
    public class GitHubOrganizationListResponse : GitHubListResponse<GitHubOrganizationItem> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubOrganizationListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubOrganizationItem.Parse);
        }

    }

}