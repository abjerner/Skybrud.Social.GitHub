using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Labels;

namespace Skybrud.Social.GitHub.Responses.Labels {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubLabel"/>.
    /// </summary>
    public class GitHubLabelResponse : GitHubResponse<GitHubLabel> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubLabelResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubLabel.Parse);
        }

    }

}