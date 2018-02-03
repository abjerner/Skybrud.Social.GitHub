using System;
using Skybrud.Social.GitHub.Models.Authentication;
using Skybrud.Social.Http;
using Skybrud.Social.Interfaces.Http;

namespace Skybrud.Social.GitHub.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to exchange an authorization code for an access token.
    /// </summary>
    public class GitHubAccessTokenResponse : GitHubResponse<GitHubAccessToken> {
        
        #region Constructors

        private GitHubAccessTokenResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);
            
            // Parse the response body into an instance of NameValueCollection
            IHttpQueryString body = SocialHttpQueryString.ParseQueryString(response.Body);
            
            Body = GitHubAccessToken.Parse(body);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubAccessTokenResponse"/>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>An instance of <see cref="GitHubAccessTokenResponse"/>.</returns>
        public static GitHubAccessTokenResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubAccessTokenResponse(response);
        }

        #endregion

    }

}