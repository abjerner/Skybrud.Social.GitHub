using System;
using Skybrud.Social.GitHub.Objects.Organizations;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response for getting information about a GitHub organiszation.
    /// </summary>
    public class GitHubGetOrganizationResponse : GitHubResponse<GitHubOrganization> {

        #region Constructor

        private GitHubGetOrganizationResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubOrganization.Parse);
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetOrganizationResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <code>SocialHttpResponse</code> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetOrganizationResponse</code> representing the response.</returns>
        public static GitHubGetOrganizationResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetOrganizationResponse(response);

        }

    }

}