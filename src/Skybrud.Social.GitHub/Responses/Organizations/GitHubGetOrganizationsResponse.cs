using System;
using Skybrud.Social.GitHub.Models.Organizations;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Organizations {

    /// <summary>
    /// Class representing the response for getting a list of GitHub organizations.
    /// </summary>
    public class GitHubGetOrganizationsResponse : GitHubResponse<GitHubOrganizationSummary[]> {

        #region Constructor

        private GitHubGetOrganizationsResponse(SocialHttpResponse response) : base(response) {
            Body = ParseJsonArray(response.Body, GitHubOrganizationSummary.Parse);
        }

        #endregion

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubGetOrganizationsResponse</code>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>Returns an instance of <code>GitHubGetOrganizationsResponse</code> representing the response.</returns>
        public static GitHubGetOrganizationsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubGetOrganizationsResponse(response);

        }

    }

}