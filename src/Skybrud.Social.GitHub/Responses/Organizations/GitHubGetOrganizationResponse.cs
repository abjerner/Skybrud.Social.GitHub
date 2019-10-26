using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response for getting information about a GitHub organiszation.
    /// </summary>
    public class GitHubGetOrganizationResponse : GitHubResponse<GitHubOrganization> {

        #region Constructors

        private GitHubGetOrganizationResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubOrganization.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetOrganizationResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetOrganizationResponse"/> representing the response.</returns>
        public static GitHubGetOrganizationResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetOrganizationResponse(response);
        }

        #endregion

    }

}