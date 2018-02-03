﻿using System;
using Skybrud.Social.GitHub.Models.Commits;
using Skybrud.Social.Http;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response for getting a list of commits.
    /// </summary>
    public class GitHubGetCommitsResponse : GitHubResponse<GitHubCommitSummary[]> {

        #region Constructors

        private GitHubGetCommitsResponse(SocialHttpResponse response) : base(response) {

            // Validate the response
            ValidateResponse(response);

            // Parse the response body
            Body = ParseJsonArray(response.Body, GitHubCommitSummary.Parse);

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetCommitsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="SocialHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitsResponse"/> representing the response.</returns>
        public static GitHubGetCommitsResponse ParseResponse(SocialHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetCommitsResponse(response);
        }

        #endregion

    }

}