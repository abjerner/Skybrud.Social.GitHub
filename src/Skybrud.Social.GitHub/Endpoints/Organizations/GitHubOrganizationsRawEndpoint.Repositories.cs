using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Organizations.Repositories;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsRawEndpoint {

        /// <summary>
        /// Returns a list of repositories of the organization matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        public IHttpResponse GetRepositories(GitHubGetRepositoriesOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}