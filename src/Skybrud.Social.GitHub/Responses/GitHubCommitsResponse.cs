using System;
using Skybrud.Social.GitHub.Objects;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses {

    public class GitHubCommitsResponse : GitHubResponse<GitHubCommitSummary[]> {

        #region Constructor

        private GitHubCommitsResponse(SocialHttpResponse response) : base(response) { }

        #endregion

        #region Static methods

        public static GitHubCommitsResponse ParseResponse(SocialHttpResponse response) {

            // Some input validation
            if (response == null) throw new ArgumentNullException("response");

            // Validate the response
            ValidateResponse(response);

            // Initialize the response object
            return new GitHubCommitsResponse(response) {
                Body = SocialUtils.ParseJsonArray(response.Body, GitHubCommitSummary.Parse)
            };

        }

        #endregion

    }

}