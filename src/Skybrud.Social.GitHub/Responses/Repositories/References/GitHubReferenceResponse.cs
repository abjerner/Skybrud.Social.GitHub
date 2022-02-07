using Skybrud.Essentials.Http;
using Skybrud.Essentials.Json;
using Skybrud.Social.GitHub.Models.Repositories.References;

namespace Skybrud.Social.GitHub.Responses.Repositories.References {
    
    /// <summary>
    /// Class representing a response with a <see cref="GitHubReference"/>.
    /// </summary>
    public class GitHubReferenceResponse : GitHubResponse<GitHubReference> {
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubReferenceResponse(IHttpResponse response) : base(response) {
            Body = JsonUtils.ParseJsonObject(response.Body, GitHubReference.Parse);
        }

    }

}