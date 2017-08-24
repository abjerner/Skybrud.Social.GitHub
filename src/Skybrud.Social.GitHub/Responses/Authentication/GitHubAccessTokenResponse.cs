using System;
using System.Collections.Specialized;
using Skybrud.Social.GitHub.Models.Authentication;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to exchange an authorization code for an access token.
    /// </summary>
    public class GitHubAccessTokenResponse : GitHubResponse<GitHubAccessToken> {
        
        #region Constructors

        private GitHubAccessTokenResponse(SocialHttpResponse response) : base(response) {

            // Parse the response body into an instance of NameValueCollection
            NameValueCollection body = SocialUtils.Misc.ParseQueryString(response.Body);
            
            Body = GitHubAccessToken.Parse(body);
        
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <code>response</code> into an instance of <code>GitHubAccessTokenResponse</code>.
        /// </summary>
        /// <param name="response">The response to be parsed.</param>
        /// <returns>Returns an instance of <code>GitHubAccessTokenResponse</code>.</returns>
        public static GitHubAccessTokenResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");
            
            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubAccessTokenResponse(response);

        }

        #endregion

    }

}