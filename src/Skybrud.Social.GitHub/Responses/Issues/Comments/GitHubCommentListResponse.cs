using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues.Comments;

namespace Skybrud.Social.GitHub.Responses.Issues.Comments {

    /// <summary>
    /// Class representing the response with a list of <see cref="GitHubComment"/>.
    /// </summary>
    public class GitHubCommentListResponse : GitHubListResponse<GitHubComment> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubCommentListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubComment.Parse);
        }

    }

}