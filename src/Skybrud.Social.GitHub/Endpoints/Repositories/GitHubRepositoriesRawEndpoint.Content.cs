using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Repositories.Content;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {
    
    public partial class GitHubRepositoriesRawEndpoint {
        
        /// <summary>
        /// Creates a new file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse CreateContent(GitHubCreateRepositoryContentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the contents of a file or directory in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#get-repository-content</cref>
        /// </see>
        public IHttpResponse GetContent(GitHubGetRepositoryContentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }
        
        /// <summary>
        /// Updates/replaces an existing file in a repository.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/repos#create-or-update-file-contents</cref>
        /// </see>
        public IHttpResponse UpdateContent(GitHubUpdateRepositoryContentOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}