using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Labels;

namespace Skybrud.Social.GitHub.Responses.Labels {

    /// <summary>
    /// Class representing the response for a list of <see cref="GitHubLabel"/>.
    /// </summary>
    public class GitHubLabelListResponse : GitHubListResponse<GitHubLabel> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubLabelListResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubLabel.Parse);
        }

    }

}