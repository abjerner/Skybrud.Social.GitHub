using Skybrud.Social.GitHub.Options.Repositories.Content;
using Skybrud.Social.GitHub.Responses.Repositories.Content;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {

        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse CreateContent(GitHubCreateRepositoryContentOptions options) {
            return new GitHubContentResponse(Raw.CreateContent(options));
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public GitHubContentResponse GetContent(GitHubGetRepositoryContentOptions options) {
            return new GitHubContentResponse(Raw.GetContent(options));
        }

        /// <summary>
        /// Updates/replaces an existing file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubContentResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public GitHubContentResponse UpdateContent(GitHubUpdateRepositoryContentOptions options) {
            return new GitHubContentResponse(Raw.UpdateContent(options));
        }

    }

}