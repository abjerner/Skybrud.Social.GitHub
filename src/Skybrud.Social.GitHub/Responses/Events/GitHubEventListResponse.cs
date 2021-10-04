using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Events;

namespace Skybrud.Social.GitHub.Responses.Events {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubEventItem"/>.
    /// </summary>
    public class GitHubEventListResponse : GitHubListResponse<GitHubEventItem> {
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubEventListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubEventItem.Parse);
        }

    }

}