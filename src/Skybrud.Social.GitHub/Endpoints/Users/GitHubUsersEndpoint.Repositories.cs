using Skybrud.Social.GitHub.Options.Users;
using Skybrud.Social.GitHub.Responses.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Users {

    public partial class GitHubUsersEndpoint {

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(int userId) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(userId));
        }

        /// <summary>
        /// Gets a list of repositories of the user with the specified <paramref name="username"/>.
        /// </summary>
        /// <param name="username">The username (login) of the user.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(string username) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(username));
        }

        /// <summary>
        /// Gets a list of repositories of the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubRepositoryListResponse"/> representing the response.</returns>
        public GitHubRepositoryListResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            return new GitHubRepositoryListResponse(Raw.GetRepositories(options));
        }

    }

}