using System;
using Skybrud.Social.GitHub.Models.Authentication;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to exchange an authorization code for an access token.
    /// </summary>
    public class GitHubTokenResponse : GitHubResponse<GitHubToken> {
        
        #region Constructors

        private GitHubTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body
            Body = GitHubToken.Parse(SocialHttpQueryString.ParseQueryString(response.Body));
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubTokenResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubTokenResponse"/> representing the response.</returns>
        public static GitHubTokenResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubTokenResponse(response);
        }

        #endregion

    }

}