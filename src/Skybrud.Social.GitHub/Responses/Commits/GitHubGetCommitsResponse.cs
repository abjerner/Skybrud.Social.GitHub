using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models;
using Skybrud.Social.GitHub.Models.Commits;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response for getting a list of commits.
    /// </summary>
    public class GitHubGetCommitsResponse : GitHubResponse<GitHubCommitSummary[]> {

        #region Properties

        /// <summary>
        /// Gets a reference to the <c>Link</c> header of the response.
        /// </summary>
        public GitHubLinkHeader Link { get; }

        #endregion

        #region Constructors

        private GitHubGetCommitsResponse(IHttpResponse response) : base(response) {
            Link = GitHubLinkHeader.Parse(response);
            Body = ParseJsonArray(response.Body, GitHubCommitSummary.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetCommitsResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitsResponse"/> representing the response.</returns>
        public static GitHubGetCommitsResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetCommitsResponse(response);
        }

        #endregion

    }

}