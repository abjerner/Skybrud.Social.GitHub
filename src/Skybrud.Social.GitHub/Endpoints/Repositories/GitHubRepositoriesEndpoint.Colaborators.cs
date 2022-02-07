using Skybrud.Social.GitHub.Options.Repositories.Collaborators;
using Skybrud.Social.GitHub.Responses;

namespace Skybrud.Social.GitHub.Endpoints.Repositories {

    public partial class GitHubRepositoriesEndpoint {
        
        /// <summary>
        /// Adda a new collaborator to the repository matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="GitHubResponse"/> representing the response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/collaborators#add-a-repository-collaborator</cref>
        /// </see>
        public GitHubResponse AddCollaborator(GitHubAddCollaboratorOptions options) {
            return new GitHubResponse(Raw.AddCollaborator(options));
        }

    }

}