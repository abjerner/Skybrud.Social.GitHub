using Skybrud.Social.GitHub.Options.Repositories.References;
using Skybrud.Social.GitHub.Responses.Repositories.References;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {
        
        /// <summary>
        /// Creates a new Git reference with the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubReferenceResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/git#create-a-reference</cref>
        /// </see>
        public GitHubReferenceResponse CreateReference(GitHubCreateReferenceOptions options) {
            return new GitHubReferenceResponse(Raw.CreateReference(options));
        }

    }

}