using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.GitHub.Models.Commits;

namespace Skybrud.Social.GitHub.Responses.Commits {

    /// <summary>
    /// Class representing the response of a call to get information about a given commit.
    /// </summary>
    public class GitHubGetCommitResponse : GitHubResponse<GitHubCommit> {

        #region Constructors

        private GitHubGetCommitResponse(IHttpResponse response) : base(response) {
            Body = ParseJsonObject(response.Body, GitHubCommit.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="response"/> into an instance of <see cref="GitHubGetCommitResponse"/>.
        /// </summary>
        /// <param name="response">The instance of <see cref="IHttpResponse"/> representing the raw response.</param>
        /// <returns>An instance of <see cref="GitHubGetCommitResponse"/> representing the response.</returns>
        public static GitHubGetCommitResponse ParseResponse(IHttpResponse response) {
            if (response == null) throw new ArgumentNullException(nameof(response));
            return new GitHubGetCommitResponse(response);
        }

        #endregion

    }

}