using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues.Comments;

namespace Skybrud.Social.GitHub.Responses.Issues.Comments {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubComment"/>.
    /// </summary>
    public class GitHubCommentResponse : GitHubResponse<GitHubComment> {
        
        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubCommentResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubComment.Parse);
        }

    }

}