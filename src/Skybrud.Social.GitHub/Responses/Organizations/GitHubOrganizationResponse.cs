using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubOrganization"/>.
    /// </summary>
    public class GitHubOrganizationResponse : GitHubResponse<GitHubOrganization> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubOrganizationResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubOrganization.Parse);
        }

    }

}