using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.GraphQl.Models.Organizations;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.GraphQl.Responses {
    
    /// <summary>
    /// Class representing a response wrapping a single <see cref="Organization"/>.
    /// </summary>
    /// <see>
    ///     <cref>https://docs.github.com/en/graphql/reference/queries#organization</cref>
    /// </see>
    public class OrganizationResponse : GitHubResponse<OrganizationResult> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public OrganizationResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, OrganizationResult.Parse);
        }

    }

}