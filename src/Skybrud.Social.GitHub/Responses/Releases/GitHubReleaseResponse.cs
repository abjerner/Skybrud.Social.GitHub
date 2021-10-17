using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Releases;

namespace Skybrud.Social.GitHub.Responses.Releases {

    /// <summary>
    /// Class representing the response with information about a <see cref="GitHubRelease"/>.
    /// </summary>
    public class GitHubReleaseResponse : GitHubResponse<GitHubRelease> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubReleaseResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubRelease.Parse);
        }

    }

}