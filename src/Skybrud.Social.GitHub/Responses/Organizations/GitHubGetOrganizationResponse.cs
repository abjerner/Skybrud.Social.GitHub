using System;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response for getting information about a GitHub organiszation.
    /// </summary>
    public class GitHubGetOrganizationResponse : GitHubResponse<GitHubOrganization> {

        #region Constructors

        private GitHubGetOrganizationResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonObject(response.Body, GitHubOrganization.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetOrganizationResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetOrganizationResponse"/> representing the response.</returns>
        public static GitHubGetOrganizationResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetOrganizationResponse(response);
        }

        #endregion

    }

}