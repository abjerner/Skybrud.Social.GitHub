using Skybrud.Social.GitHub.Options.Organizations.Repositories;
using Skybrud.Social.GitHub.Responses.Repositories;
using System;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsEndpoint {
        
        /// <summary>
        /// Returns a list of repositories of the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return new GitHubRepositoryListResponse(Raw.GetRepositories(options));
        }

    }

}