using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Social.GitHub.Models.Authentication;

namespace Skybrud.Social.GitHub.Responses.Authentication {

    /// <summary>
    /// Class representing the response of a call to exchange an authorization code for an access token.
    /// </summary>
    public class GitHubTokenResponse : GitHubResponse<GitHubToken> {

        /// <summary>
        /// Initializes a new instance from the specified <paramref name="response"/>.
        /// </summary>
        /// <param name="response">The raw response the instance should be based on.</param>
        public GitHubTokenResponse(IHttpResponse response) : base(response) {
            Body = GitHubToken.Parse(HttpQueryString.ParseQueryString(response.Body));
        }

    }

}