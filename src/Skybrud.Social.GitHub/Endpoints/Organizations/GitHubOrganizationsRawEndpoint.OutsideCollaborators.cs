using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Options.Organizations.OutsideCollaborators;

namespace Skybrud.Social.GitHub.Endpoints.Organizations {

    public partial class GitHubOrganizationsRawEndpoint {

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="organization"/>.
        /// </summary>
        /// <param name="organization">The alias (username) of the organization.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public IHttpResponse GetOutsideCollaborators(string organization) {
            if (string.IsNullOrWhiteSpace(organization)) throw new ArgumentNullException(nameof(organization));
            return GetOutsideCollaborators(new GitHubGetOutsideCollaboratorsOptions(organization));
        }

        /// <summary>
        /// Gets a list of the outside collaborators of the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://docs.github.com/en/rest/reference/orgs#list-outside-collaborators-for-an-organization</cref>
        /// </see>
        public IHttpResponse GetOutsideCollaborators(GitHubGetOutsideCollaboratorsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

    }

}