using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Organizations;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response for getting a list of GitHub organizations.
    /// </summary>
    public class GitHubGetOrganizationsResponse : GitHubResponse<GitHubOrganizationItem[]> {

        #region Constructors

        private GitHubGetOrganizationsResponse(IHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, GitHubOrganizationItem.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetOrganizationsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetOrganizationsResponse"/> representing the response.</returns>
        public static GitHubGetOrganizationsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetOrganizationsResponse(response);
        }

        #endregion

    }

}