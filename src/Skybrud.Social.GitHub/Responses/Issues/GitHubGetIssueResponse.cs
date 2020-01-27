using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Issues;

namespace Skybrud.Social.GitHub.Responses.Issues {

    /// <summary>
    /// Class representing the response for getting information about a GitHub issue.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.github.com/v3/issues/#get-a-single-issue</cref>
    /// </see>
    public class GitHubGetIssueResponse : GitHubResponse<GitHubIssue> {

        #region Constructors

        private GitHubGetIssueResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubIssue.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetIssueResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetIssueResponse"/> representing the response.</returns>
        public static GitHubGetIssueResponse Parse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetIssueResponse(response);
        }

        #endregion

    }

}