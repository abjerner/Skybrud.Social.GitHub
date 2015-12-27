using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubEmailsResponse : GitHubResponse<GitHubEmail[]> {

        #region Constructor

        private GitHubEmailsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        public static GitHubEmailsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubEmailsResponse(response) {
                Body = SocialUtils.ParseJsonArray(response.Body, GitHubEmail.Parse)
            };

        }

    }

}